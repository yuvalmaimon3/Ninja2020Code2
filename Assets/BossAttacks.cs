using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public AudioSource firstScream;
    public  AudioSource swardsSound;
    public BoxCollider rightHand;
    public BoxCollider leftHand;
    public Transform starMagazine;
    private float timeCounter = 0;
    private bool isAttack = false;
    private Animator enemyAnimator;
    private FlipEnemy flipEnemy;
    private EnemyHealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = transform.parent.GetComponent<Animator>();
        flipEnemy = transform.parent.GetComponent<FlipEnemy>();
        enemyHealth = transform.parent.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= 10f)
            if (enemyHealth.aLive)
                if (!isAttack)
                {
                    StartCoroutine(NovaStar());

                }
    } 
    private IEnumerator Attacking()
    {

            isAttack = true;
            enemyAnimator.SetBool("Move", false);
            rightHand.enabled = true;
            leftHand.enabled = true;      
            enemyAnimator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.2f);
            swardsSound.Play();
            yield return new WaitForSeconds(0.8f);
            rightHand.enabled = false;
            leftHand.enabled = false;
            isAttack = false;

    }
    private void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player")
            if (enemyHealth.aLive)
                if (player.GetComponent<Health>().isAlive)
                {
                    flipEnemy.ifAttack = true;
                    if (!isAttack)
                    {                      
                        StartCoroutine(Attacking());
                    }
                }
                else OnTriggerExit(player);
    
    }


    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
            if (enemyHealth.aLive)

            {
                Debug.Log("Exit from collider");
                flipEnemy.ifAttack = false;
                enemyAnimator.SetBool("Move", true);
            }
    
    }

    private IEnumerator NovaStar()
    {
        for (int i = 0; i < 2; i++)
        {
            isAttack = true;
            enemyAnimator.SetBool("Move", false);
            yield return new WaitForSecondsRealtime(0.5f);
            enemyAnimator.SetTrigger("NovaAttack");
            firstScream.Play();
            float rotate_angel = Random.Range(0, 90);
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            yield return new WaitForSecondsRealtime(0.3f); // Timing animator with instantiate
            Instantiate(starMagazine, position, Quaternion.Euler(0, 0, Random.Range(1, 45)));
            yield return new WaitForSeconds(0.4f);
            isAttack = false;
            enemyAnimator.SetBool("Move", true);
            timeCounter = 0;

        }
    }
}
