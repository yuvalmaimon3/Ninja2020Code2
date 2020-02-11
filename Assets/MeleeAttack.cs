using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public BoxCollider axeCollider;
    public AudioSource Axevoice;
    private bool isAttack = false;
    private Animator enemyAnimator;
    private FlipEnemy moveAndFlipEnemy;
    private EnemyHealth enemyHealth;
    private BoxCollider Sensor;
   
    // Start is called before the first frame update
    void Start()
    {
        Sensor = GetComponent<BoxCollider>();
        //   Sounds = GetComponent<AudioSource>();
        enemyAnimator = transform.parent.GetComponent<Animator>();
        moveAndFlipEnemy = transform.parent.GetComponent<FlipEnemy>();
        enemyHealth = transform.parent.GetComponent<EnemyHealth>();

    }

    private IEnumerator Attacking()
    {

        isAttack = true;
        enemyAnimator.SetBool("Move", false);
        Axevoice.Play();
        yield return new WaitForSeconds(0.1f);
        enemyAnimator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f);
        axeCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        axeCollider.enabled = false;
        yield return new WaitForSeconds(0.9f);
        isAttack = false;

    } 
    
    private void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player")
            if (enemyHealth.aLive)
                if (player.GetComponent<Health>().isAlive) // check if the player a live because else its dont detect the object get out from trigger.
                {
                    moveAndFlipEnemy.ifAttack = true;
                    if (!isAttack)
                    {
                        StartCoroutine(Attacking());
                    }
                }
                else
                {
                   
                    OnTriggerExit(player);
                }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            if (enemyHealth.aLive)
            {
                moveAndFlipEnemy.ifAttack = false;
                enemyAnimator.SetBool("Move", true);
            }
    }
}
