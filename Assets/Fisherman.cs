using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisherman : MonoBehaviour
{
    private Animator fishermanAnimator;
    // Start is called before the first frame update
    void Start()
    {
        fishermanAnimator = GetComponent<Animator>();
        StartCoroutine(Fishing());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator Fishing()
    {
        
        for (int i = 0; i < 1; i++)
        {        
            fishermanAnimator.SetTrigger("Drop");
            yield return new WaitForSeconds(5f); 
        }
        StartCoroutine(Fishing());
    }
}
