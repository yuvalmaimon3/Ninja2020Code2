using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAndChangeAudioClip : MonoBehaviour
{
    private AudioSource environmentAudio;
    public AudioClip bossClip;

    private void Start()
    {
        environmentAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider player)
    {
     if(player.tag == "Player")
        {
            StartCoroutine(ChangeClip());
        }
        
    }

    private IEnumerator ChangeClip()
    {
        environmentAudio.Stop();
        yield return new WaitForSeconds(2f);
        environmentAudio.clip = bossClip;
        environmentAudio.Play();

    }
}
