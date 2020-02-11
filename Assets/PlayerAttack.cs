using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform Projectail;
    public Animator playerAnimator;
    public float attckSpeed = 2f;
    private Health playerHealth;
    private bool isAttack;
    private AudioSource throwSound;

    // Start is called before the first frame update
    void Start()
    {
        isAttack = false;
        throwSound = GetComponent<AudioSource>();
        playerHealth = transform.parent.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Attacking());
    }



    private IEnumerator Attacking()
    {
        if (Input.GetKey("space"))
            if (playerHealth.isAlive)
                if (!isAttack)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        isAttack = true;
                        playerAnimator.SetTrigger("Attack");
                        yield return new WaitForSeconds(0.2f);
                        throwSound.Play();
                        if (transform.parent.rotation.y > 0.70)
                            Instantiate(Projectail, transform.position, Quaternion.Euler(90, 0, -90));
                        else
                            Instantiate(Projectail, transform.position, Quaternion.Euler(90, 0, 90));
                        yield return new WaitForSeconds(attckSpeed);
                    }
                    isAttack = false;
                }
    
    }


}
