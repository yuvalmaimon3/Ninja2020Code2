using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axecollation2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            var player_hp = other.GetComponent<Health>();
            player_hp.Damage(-50);
        }
    }
}
