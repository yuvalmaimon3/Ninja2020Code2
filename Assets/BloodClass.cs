using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodClass : MonoBehaviour
{
    public static Transform bloodPrefab;

    // Start is called before the first frame update
    void Start()
    {
        bloodPrefab = gameObject.GetComponent<Transform>();
        Destroy(gameObject, 3f);
    }
    

}
