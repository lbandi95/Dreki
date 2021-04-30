using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class VillanyLe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.Find("Global Light 2D").GetComponent<Light2D>().intensity>0.05f)
        {
            GameObject.Find("Global Light 2D").GetComponent<Light2D>().intensity = 0.05f;
        }
    }
    
}
