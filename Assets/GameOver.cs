using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public EnemyHealth bossHealth;
    public GameObject gameOverImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHealth.aLive == false)
            gameOverImage.SetActive(true);
    }
}
