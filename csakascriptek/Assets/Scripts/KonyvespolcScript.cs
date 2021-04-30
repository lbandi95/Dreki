using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonyvespolcScript : MonoBehaviour
{
    
    void Update()
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite == 
            gameObject.GetComponent<Interactable>().altsprite)
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            GameObject.Find("konyvespolcszilank").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("konyvespolcszilank").GetComponent<CircleCollider2D>().enabled = true;
            gameObject.GetComponent<KonyvespolcScript>().enabled = false;
        }
    }
}
