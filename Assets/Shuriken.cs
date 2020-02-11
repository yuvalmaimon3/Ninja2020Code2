using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{

    public float Speed = 30;
    public float Dmg;
    public float destroyTimer;
    public  Transform blood;
    Rigidbody projectailRB;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTimer);
        projectailRB = GetComponent<Rigidbody>();
        Dmg = 30;        
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
        if(other.tag == "Enemy")
        {
          
            transform.Find("Blood").gameObject.SetActive(true);
            transform.Find("Blood").parent = other.transform;
            EnemyHealth enemyhp = other.GetComponent<EnemyHealth>();
            enemyhp.Damaged(Dmg);
            Destroy(gameObject);
            
        }
    }
}
