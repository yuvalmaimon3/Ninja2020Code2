using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoss : MonoBehaviour
{
    public GameObject Stone1;
    public GameObject Stone2;
    public GameObject Boss;

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            Stone1.SetActive(true);
            Stone2.SetActive(true);
            Boss.SetActive(true);
        }

    }
}
