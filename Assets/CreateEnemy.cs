using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject TrapEnemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TrapEnemy.SetActive(true);
            Destroy(gameObject);
        }
                
    }
}
