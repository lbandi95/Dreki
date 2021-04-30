using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zenekapcsolo : MonoBehaviour
{
    public AudioSource audioSrc;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!audioSrc.isPlaying)
        {
        Invoke("ZeneIndit", 1f);
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        audioSrc.Stop();
    }
    public void ZeneIndit()
    {
        audioSrc.Play();    
    }
}
