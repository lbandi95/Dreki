using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Interactable : MonoBehaviour
{
    public bool inventory;
    public bool openable;
    public bool locked;
    public bool usable;
    public bool spriteChange;
    public bool lightSwitch;
    public bool simplespriteChange;
    public bool trap;
    public bool deactivateable;
    public bool lighter;
    public GameObject itemNeeded;
    public Animator anim;
    public Animator trapFadeAnim;
    public AudioSource audioSrc;
    public AudioClip[] sounds;
    public Sprite altsprite;
    public Sprite originalsprite;
    public Vector2 destination;
    

    public void DoInteraction()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        if (gameObject.GetComponent<PolygonCollider2D>())
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
        if (gameObject.name=="pinceszilank")
        {
            GameObject.Find("Szilankfeny").SetActive(false);
        }
        if (gameObject.name=="Kulcs2")
        {
            Invoke("Disable", 0.55f);
        }
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }
    public void PlaySFX()
    {
        audioSrc.PlayOneShot(sounds[0]);
    }
    public void Open()
    { 
        if (gameObject.name != "Kapu")
        {
            PlaySFX();
            anim.SetBool("open", true);
                   
        }
        else
        {
            GameObject.Find("Player").GetComponent<Inventory>().TerminateInventory();
            anim.SetBool("open", true);
            Invoke("PlaySFX", 0.1f);
        }
    }
    public void Try()
    {
        audioSrc.PlayOneShot(sounds[1]);
    }

    public void Use()
    {
        if (gameObject.name == "labirintuskar")
        {
            GameObject.Find("labirintusajto").GetComponent<Animator>().SetTrigger("open");
            anim.SetTrigger("pulled");
            GameObject.Find("FaklyaKi").GetComponent<EdgeCollider2D>().enabled = true;
            PlaySFX();
        }
        if (gameObject.name == "faklya")
        {
            Invoke("TorchOn", 1f);
            Invoke("CloseDoor", 2f);
        }
        if (gameObject.name == "KepFalon")
        {
            for (int i = 0; i < GameObject.Find("Player").GetComponent<Inventory>().inventory.Length; i++)
            {
                if (GameObject.Find("Player").GetComponent<Inventory>().inventory[i] == itemNeeded)
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    GameObject.Find("Player").GetComponent<Inventory>().DeleteItem(itemNeeded);
                    GameObject.Find("fiok2").GetComponent<Animator>().SetBool("kep", true);
                    PlaySFX();
                    break;
                }
            }
        }
        if(gameObject.name == "templomgyertya")
        {
            Invoke("LightCandle", 0.75f);
        }
        if(gameObject.name == "templomfaklya")
        {
            anim.SetTrigger("start");
            GameObject.Find("fiok2").GetComponent<Animator>().SetBool("faklya", true);
            PlaySFX();
        }
        if (gameObject.name == "Fuggony")
        {
            anim.SetTrigger("Start");
            PlaySFX();
            GetComponent<CircleCollider2D>().enabled=false;
        }
        if (gameObject.name =="Konyvespolc")
        {
            anim.SetTrigger("Start");
            GameObject.Find("konyvespolcszilank").GetComponent<CircleCollider2D>().enabled=true;
        }
    }
    private void LightCandle()
    {
        anim.SetTrigger("start");
        GameObject.Find("fiok2").GetComponent<Animator>().SetBool("gyertya", true);
        PlaySFX();
    }

    /*public void LightsOn()
    {
        PlaySFX();
        GameObject.Find("Fuggony").GetComponent<SpriteRenderer>().sprite = altsprite;
        GameObject.Find("Ablak Feny").GetComponent<Light2D>().enabled = true;
        Invoke("ShieldShine", 0.5f);
        GameObject.Find("PinceFeny").GetComponent<Light2D>().pointLightOuterRadius = 24;
        if (GameObject.Find("Player").GetComponent<GameManager>().shinyKeyPicked == false)
        {
            GameObject.Find("Szilankfeny").GetComponent<Light2D>().enabled = true;
        }
    }
    public void ShieldShine()
    {
        GameObject.Find("Pajzs Feny").GetComponent<Light2D>().enabled = true;
    }
    public void LightsOff()
    {
        PlaySFX();
        GameObject.Find("Fuggony").GetComponent<SpriteRenderer>().sprite = originalsprite;
        GameObject.Find("Ablak Feny").GetComponent<Light2D>().enabled = false;
        GameObject.Find("Pajzs Feny").GetComponent<Light2D>().enabled = false;
        GameObject.Find("PinceFeny").GetComponent<Light2D>().pointLightOuterRadius = 10;
        if (GameObject.Find("Szilankfeny").GetComponent<Light2D>().enabled == true)
        {
            GameObject.Find("Szilankfeny").GetComponent<Light2D>().enabled = false;
        }
        
    }*/
    public void SpriteChange()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = altsprite;
        PlaySFX();
    }
    public void Trap()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        anim.SetTrigger("Start");
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("Traphit");
        //anim+audio
        //invoke kép elsötétül
        Invoke("StartAnim", 0.5f);
        //invoke player vissza az elejére
        Invoke("SetPos", 1f);
        //invoke kép vissza
        Invoke("EndAnim", 1.2f);
        
    }
    public void Deactivate()
    {
        trap = false;
        anim.SetTrigger("Deakt");
    }
    private void StartAnim()
    {
        trapFadeAnim.SetTrigger("Start");
    }
    private void EndAnim()
    {
        trapFadeAnim.SetTrigger("End");
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("Respawn");
        trap = false;
        if(gameObject.GetComponent<BoxCollider2D>() && !deactivateable)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger=false;
        }
    }
    private void SetPos()
    {
        GameObject.Find("Player").transform.position = destination;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        if (GameObject.Find("Global Light 2D").GetComponent<Light2D>().intensity != 0f)
        {
            GameObject.Find("Global Light 2D").GetComponent<Light2D>().intensity = 0f;
        }
    }
    private void CloseDoor()
    {
        GameObject.Find("labirintusajto").GetComponent<Animator>().SetTrigger("close");
    }
    private void TorchOn()
    {
        GameObject.Find("Playerfeny").GetComponent<Light2D>().enabled = true;
    }
}
