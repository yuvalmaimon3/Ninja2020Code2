using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTheBlocker : MonoBehaviour
{
    public GameObject Stone;
    private void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player")
          Stone.SetActive(true);
    }
}
