using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSensor : MonoBehaviour
{
    private FlipEnemy backColl;
    private EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        backColl = transform.parent.GetComponent<FlipEnemy>();
        enemyHealth = transform.parent.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(enemyHealth.aLive)
        if(other.tag == "Player")
        {
            if (backColl.lookDir == "right")
            {
                backColl.lookDir = "left";
                backColl.FlipCharacterSide("left");
            }
            else
            {
                backColl.FlipCharacterSide("right");
                backColl.lookDir = "right";
            }
        }
    }
}
