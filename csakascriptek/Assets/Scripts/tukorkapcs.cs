using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tukorkapcs : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject.Find("PlayerReflection").GetComponent<SpriteRenderer>().enabled = true;
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        GameObject.Find("PlayerReflection").GetComponent<SpriteRenderer>().enabled = false;
    }
}
