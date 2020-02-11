using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightEnemtPrijectail : MonoBehaviour
{

    public float Speed = 30;
    private Rigidbody projectailRB;
    // Start is called before the first frame update
    void Start()
    {
        projectailRB = GetComponent<Rigidbody>();
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
            Health health = other.GetComponent<Health>();
            health.Damage(10);
            Destroy(gameObject);
        }
    }

}
