using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemy : MonoBehaviour
{
    public bool ifAttack = false;
    public  string lookDir = "right";
    private Animator enemyAnimator;
    public Transform Point1;
    public Transform Point2;
    private EnemyHealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        ifAttack = false;
        enemyAnimator = GetComponent<Animator>();
        enemyAnimator.SetBool("Move", true);
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.aLive == true )
            if(!ifAttack)
        {
            Move();
        }
    }

    private void Move()
    {
       // float waypoint_distance;
        
        if (lookDir == "right")
        {

            if (transform.position.x >= Point2.position.x) // כאשר האיקס שלי יגדל מנקודת ציון
            {
             
                FlipCharacterSide("left");

                lookDir = "left";
            }
        }
        else if (lookDir == "left")
        {
            if (transform.position.x <= Point1.position.x) //כאשר האיקס שלי יגדל מנקודת ציון
            {
               
                FlipCharacterSide("right");
                lookDir = "right";
            }
        }

    }


    public void FlipCharacterSide(string side)
    {
        if (side == "right")
        {
            if (transform.rotation.eulerAngles.y != 90)
            {
                transform.localRotation = Quaternion.Euler(0, 90, 0);   //change to global/local rotation relative to unity north
          
            }
        }
        else if (side == "left")
        {
            if (transform.rotation.eulerAngles.y != -90)
            {
                transform.localRotation = Quaternion.Euler(0, -90, 0);      //change to global/local rotation relative to unity north
                //transform.Rotate(0f, 180f, 0f);
            }
        }
    }
}
