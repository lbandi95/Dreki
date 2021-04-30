using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FaklyaKi : MonoBehaviour
{  //faklya check
public bool kozel;
public bool mehete;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        kozel = true;
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        kozel = false;
    }
    private void Update() 
    {
        if (Input.GetButtonDown("Interact") && kozel)
        {
            mehete = true;         
        }
    }
}
