using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator playerAnimator;
    public Transform Point;
    public Transform enemyProjectail;
    private EnemyHealth enemyHealth;

    private bool isAttack = false;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator =  transform.parent.GetComponent<Animator>();
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
            playerAnimator.SetBool("Move", false);
            playerAnimator.SetTrigger("Attack");
            if(player_dir == "right")
            Instantiate(enemyProjectail, Point.position, Quaternion.Euler(0, 0, 0));
            else if(player_dir == "left")
            Instantiate(enemyProjectail, Point.position, Quaternion.Euler(0, 0,180));
            yield return new WaitForSeconds(2f);

        }
        isAttack = false;
    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && enemyHealth.aLive == true)
        {
            playerAnimator.SetBool("Move", true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && enemyHealth.aLive == true)
            if(!isAttack)
            StartCoroutine(Attacking());
    }



}
