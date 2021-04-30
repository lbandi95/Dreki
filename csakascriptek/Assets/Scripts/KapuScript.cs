using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapuScript : MonoBehaviour
{
    public Inventory inventory;
    
    private bool locked;
    private void Update()
    {
        if (inventory.Kulcsok())
        {
            gameObject.GetComponent<Interactable>().locked = false;
            gameObject.GetComponent<Interactable>().openable = true;
        }
        if (Input.GetButtonDown("Interact") && locked)
        {
            gameObject.GetComponent<Interactable>().Try();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (gameObject.GetComponent<Interactable>().locked)
        {
            locked = true;
        }
        else
        {
            locked = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        locked = false;
    }
}
