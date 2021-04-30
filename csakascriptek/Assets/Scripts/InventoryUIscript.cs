using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIscript : MonoBehaviour
{
    public Inventory inventory;
    public int slotindex;

    private void Update()
    {
        if (inventory.inventory[slotindex] != null)
        {
            //this.GetComponent<Image>().sprite = inventory.inventory[slotindex].GetComponent<SpriteRenderer>().sprite;
            this.GetComponent<Image>().sprite = inventory.inventory[slotindex].GetComponent<IconSpriteContainer>().icon;
            Color uj = this.GetComponent<Image>().color;
            uj.a = 1f;
            this.GetComponent<Image>().color = uj;
        }
        else
        {
            Color uj = this.GetComponent<Image>().color;
            uj.a = 0f;
            this.GetComponent<Image>().sprite = null;
            this.GetComponent<Image>().color = uj;
        }
    }
}
