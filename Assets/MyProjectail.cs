using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyProjectail : MonoBehaviour
{
    public float Speed = 30;
    Rigidbody projectailRB;
    public float Dmg;
    // Start is called before the first frame update
    void Start()
    {
        projectailRB = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        projectailRB.velocity = transform.TransformDirection(0, Speed, 0);
        transform.Rotate(0, 10, 0, Space.Self);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            EnemyHealth enemyhp = other.GetComponent<EnemyHealth>();
            enemyhp.Damaged(Dmg);
            Destroy(gameObject);
        }
    }
}
