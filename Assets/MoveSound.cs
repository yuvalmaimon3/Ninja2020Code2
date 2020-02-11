using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSound : MonoBehaviour
{
    private EnemyHealth enemyHealth;
    public AudioSource moveSound;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!enemyHealth.aLive)
        {
            moveSound.Stop();
        }

    }
}
