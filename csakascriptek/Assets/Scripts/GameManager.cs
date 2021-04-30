using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject currentInter = null;
    public Interactable currentInterScript = null;
    public Inventory inventory;
    //private bool curtain = false;
    public AudioSource playerSFX;
    public AudioClip[] sounds;
    private void PlaySFX()
    {
        playerSFX.volume=1f;
        playerSFX.PlayOneShot(sounds[0]);
    }
    private void PlayAltSFX()
    {
        playerSFX.volume=0.5f;
        playerSFX.PlayOneShot(sounds[1]);
    }
    private void PlayZippo()
    {
        playerSFX.volume=0.5f;
        playerSFX.PlayOneShot(sounds[2]);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInter)
        {
            if (currentInterScript.lighter)
            {
                PlayZippo();
            }
            if (currentInterScript.inventory)
            {
                inventory.AddItem(currentInter);
                Invoke("PlaySFX", 0.2f);
            }
            if (currentInterScript.openable)
            {
                if (currentInterScript.locked)
                {
                    if (inventory.FindItem(currentInterScript.itemNeeded))
                    {
                        currentInterScript.locked = false;
                        currentInterScript.Open();
                        if(currentInterScript.GetComponent<EdgeCollider2D>())
                        {
                            currentInterScript.GetComponent<EdgeCollider2D>().enabled = false;
                        }                       
                        inventory.DeleteItem(currentInterScript.itemNeeded);
                    }
                    else
                    {
                        currentInterScript.Try();
                        Invoke("PlayAltSFX", 1f);
                    }
                }
                else
                {
                    currentInterScript.Open();
                    if (currentInter.GetComponent<EdgeCollider2D>())
                    {
                        currentInter.GetComponent<EdgeCollider2D>().enabled = false;
                    }
                    
                }
            }
            if (currentInterScript.usable)
            {
                currentInterScript.Use();
            }
            if (currentInterScript.spriteChange)
            {
                if(currentInter.GetComponent<ArmorScript>())
                {
                    currentInter.GetComponent<ArmorScript>().SetSprite();
                }
            }
            /*if (currentInterScript.lightSwitch)
            {
                if (currentInter.name == "Kotel")
                {
                    if (curtain == false)
                    {
                        currentInterScript.LightsOn();
                        curtain = true;
                    }
                    else
                    {
                        currentInterScript.LightsOff();
                        curtain = false;
                    }
                }
            }*/
            if (currentInterScript.simplespriteChange)
            {
                currentInterScript.SpriteChange();
            }
            if (currentInterScript.trap && currentInterScript.deactivateable)
            {                
                currentInterScript.Deactivate();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("interactable"))
        {
            currentInter = collision.gameObject;
            currentInterScript = currentInter.GetComponent<Interactable>();
        }
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        if (currentInterScript!=null && currentInterScript.trap)
        {
            Debug.Log("csapda teruleten vagy");
            if(currentInter.GetComponent<BoxCollider2D>())
            {
                Debug.Log("box collider megvan");
                if(gameObject.GetComponent<CapsuleCollider2D>().IsTouching(currentInter.GetComponent<BoxCollider2D>()))
                {
                    Debug.Log("hozzaertel a boxcolliderhez");
                    Invoke("Trap", 0.2f);
                }
            }
        }
    }
    private void Trap()
    {
        currentInterScript.Trap();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("interactable"))
        {
            if (collision.gameObject == currentInter)
            {
                currentInter = null;
                currentInterScript = null;
            }
        }
    }
}
