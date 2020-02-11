using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuriAttack : MonoBehaviour
{
    private Animator samuriAnimator;
    public Transform Point;
    private FlipEnemy moveAndFlipEnemy;
    public Transform enemyProjectail;
    private EnemyHealth enemyHealth;

    private bool isAttack = false;


    // Start is called before the first frame update
    void Start()
    {
        moveAndFlipEnemy = transform.parent.GetComponent<FlipEnemy>();
        samuriAnimator =  transform.parent.GetComponent<Animator>();
        enemyHealth = transform.parent.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private IEnumerator Attacking()
    {
        for (int i = 0; i < 1; i++)
        {
            var player_dir = transform.parent.gameObject.GetComponent<FlipEnemy>().lookDir;  //משיג את כיוון המבט דרך האבא

            isAttack = true;
            samuriAnimator.SetBool("Move", false);
            samuriAnimator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.2f);
            if (player_dir == "right")
            Instantiate(enemyProjectail, Point.position, Quaternion.Euler(90, 0, -90));
            else if(player_dir == "left")
            Instantiate(enemyProjectail, Point.position, Quaternion.Euler(90, 0,90));
            yield return new WaitForSeconds(1f);

        }
        isAttack = false;
    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && enemyHealth.aLive == true)
        {
            samuriAnimator.SetBool("Move", true);
            moveAndFlipEnemy.ifAttack = false;
        }
    }
    private void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player")
            if (enemyHealth.aLive)
                if (player.GetComponent<Health>().isAlive)
                {
                    moveAndFlipEnemy.ifAttack = true;
                    if (!isAttack)
                    {
                        StartCoroutine(Attacking());
                    }
                }
                else OnTriggerExit(player);
    }



}
