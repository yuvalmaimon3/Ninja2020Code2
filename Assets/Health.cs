using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Vector3 spwanLocation;
    public Transform spawnEffect;
    public Image healthBar;
    public bool isAlive = true;
    public float myHealth = 100f;
    public AudioClip deadClip;
    public AudioClip spwanClip;

    private Animator playerAnimator;
    private AudioSource playerAudioSour;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAudioSour = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = myHealth / 100f;
    }

    public void Damage(float dmg)
    {
        myHealth -= dmg;

        if (myHealth <= 0)
        {
            isAlive = false;
            playerAnimator.SetTrigger("Dead");
            playerAudioSour.clip = deadClip;
            playerAudioSour.Play();
            StartCoroutine(Spawn());
        }
    }
    public void Heals(float amount)
    {
        myHealth += amount;
        if (myHealth > 100)
            myHealth = 100;
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        transform.position = spwanLocation;
        playerAudioSour.clip = spwanClip;
        playerAudioSour.Play();
        myHealth = 100;
        isAlive = true;
        playerAnimator.SetTrigger("Idle");
        GetComponent<CharacterController>().enabled = true;
        Instantiate(spawnEffect, transform.position, Quaternion.identity);
    }
}
