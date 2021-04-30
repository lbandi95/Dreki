using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FootstepChanger : MonoBehaviour
{
    public bool dirtOrstone;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.CompareTag("Player")){
            GameObject.Find("Player").GetComponent<PlayerMovement>().dirtOrstone=dirtOrstone;
        }
    }
}
