using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAttack : MonoBehaviour
{
    private bool hitReload = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(hitReload)
            if(other.tag == "Player")
            {
                hitReload = false;
                StartCoroutine(HitMe(other));
            }
    }


    private IEnumerator HitMe(Collider other)
    {
        for (int i = 0; i < 1; i++)
        {
            
            Health player_health = other.gameObject.GetComponent<Health>();
            player_health.Damage(5);
            yield return new WaitForSeconds(1f);
            hitReload = true;
        }
    }

}
