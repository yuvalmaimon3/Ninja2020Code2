using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUpAndDown : MonoBehaviour
{
    private Rigidbody rd;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(Vector3.up * 5);
    }
    private void FixedUpdate()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        
        if(other.tag == "Mushroom")
        {
      //      other.GetComponent<Rigidbody>().AddForce(transform.up * 50, ForceMode.Acceleration);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Mushroom")
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up * 500, ForceMode.Force);
        }
    }

}
