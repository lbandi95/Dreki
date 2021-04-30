using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[6];
    public void AddItem(GameObject item)
    {
        bool itemAdded = false;
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                itemAdded = true;
                item.SendMessage("PlaySFX");
                item.SendMessage("DoInteraction");
                break;
            }
        }
        if (!itemAdded)
        {
            //inventory full? nem fordulhat elő
        }
    }
    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                return true;
            }
        }       
        return false;       
    }
    public void DeleteItem(GameObject item)
    {
        for (int i = 2; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                inventory[i] = null;
            }
        }
    }
    public bool Kulcsok()
    {
        bool key1 = false;
        bool key2 = false;
        bool key3 = false;
        bool key4 = false;
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i]!=null && inventory[i].name == "nagyszilank")
            {
                key1 = true;
            }
            if (inventory[i] != null && inventory[i].name == "pinceszilank")
            {
                key2 = true;
            }
            if (inventory[i] != null && inventory[i].name == "szobrosszilank")
            {
                key3 = true;
            }
            if (inventory[i] != null && inventory[i].name == "konyvespolcszilank")
            {
                key4 = true;
            }
        }
        if (key1 && key2 && key3 && key4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void TerminateInventory()
    {
        
        for (int i = 2; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                inventory[i].GetComponent<IconSpriteContainer>().icon = null;
                inventory[i] = null;
            }
            //Destroy(inventory[i]);
            //inventory[i] = null;
        }
    }
}
