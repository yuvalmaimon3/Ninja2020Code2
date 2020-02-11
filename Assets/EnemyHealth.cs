using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private AudioSource deadSound;
    public bool aLive = true;
    public Image HP_image;
    private Animator enemyAnimator;    
    public float Health = 100;
    public float currentHealth;
    void Start()
    {

        currentHealth = Health;
        deadSound = GetComponent<AudioSource>();
        enemyAnimator = GetComponent<Animator>();
        enemyAnimator.SetBool("Dead", false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Damaged(float dmg)
    {
        StartCoroutine(GetDamaged(dmg));
    }
    private IEnumerator GetDamaged(float dmg)
    {
        currentHealth = currentHealth - dmg;
        HP_image.fillAmount =  currentHealth / Health;
        if(currentHealth <= 0 && aLive)
        {
            aLive = false;
            enemyAnimator.SetTrigger("Dead");
            deadSound.Play();
            foreach (Collider c in GetComponents<Collider>())
            {
                c.enabled = false;
            }
            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }
    }
}
