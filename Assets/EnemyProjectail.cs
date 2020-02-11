using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectail : MonoBehaviour
{
    public GameObject bloodEffect;
    public float Speed = 30;
    private Rigidbody projectailRB;
    // Start is called before the first frame update
    void Start()
    {
        projectailRB = GetComponent<Rigidbody>();
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        projectailRB.velocity = transform.TransformDirection(0, Speed, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Transform blood_effect = transform.Find("BloodSprayEffect").parent = other.transform;
            bloodEffect.gameObject.SetActive(true);
            Health health = other.GetComponent<Health>();
            health.Damage(5);
            Destroy(gameObject);
        }
    }

}
