using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCollid : MonoBehaviour
{
    public float destroyAfter = 5f;
    public GameObject destroyObject;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        Destroy(destroyObject, destroyAfter);
    }
}
