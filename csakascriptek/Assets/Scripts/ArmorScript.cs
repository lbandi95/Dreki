using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ArmorScript : MonoBehaviour
{    
    public int aktualsprite;
    public Sprite balalso;
    public Sprite balfelso;
    public Sprite jobbfelso;
    public Sprite jobbalso;
    public AudioSource audioSrc;

    private void Start()
    {
        aktualsprite = Random.Range(1, 4);
    }
    private void Update()
    {
        if (aktualsprite==1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = balalso;
        }
        else if (aktualsprite==2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = balfelso;
        }
        else if (aktualsprite == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = jobbfelso;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = jobbalso;
        }
    }
    public void SetSprite()
    {
            Debug.Log("sprite cserelve");
            if (aktualsprite <= 3)
            {
                aktualsprite = aktualsprite + 1;
                audioSrc.Play();
            }
            else
            {
                aktualsprite = 1;
                audioSrc.Play();
            }
    }
    
    
}
