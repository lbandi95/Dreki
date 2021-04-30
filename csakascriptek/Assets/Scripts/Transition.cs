using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject Player;
    public Vector2 Cel;
    public Camera PrevCamera;
    public Camera NextCamera;
    public GameObject prevCMCam;
    public GameObject nextCMCam;

    void TransPos()
    {
        Player.transform.position = Cel;
        PrevCamera.gameObject.SetActive(false);
        //PrevCamera.GetComponent<AudioListener>().enabled = false;
        NextCamera.gameObject.SetActive(true);
        //NextCamera.GetComponent<AudioListener>().enabled = true;
        if (prevCMCam!=null)
        {
            prevCMCam.gameObject.SetActive(false);
        }
        if (nextCMCam!=null)
        {
            nextCMCam.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            /*anim.SetTrigger("Start");
            Invoke("TransPos", 0.35f);*/
            TransPos();      
        }
        
    }
    
}
