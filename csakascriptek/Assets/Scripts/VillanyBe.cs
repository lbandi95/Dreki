using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class VillanyBe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.Find("Global Light 2D").GetComponent<Light2D>().intensity < 1f)
        {
            GameObject.Find("Global Light 2D").GetComponent<Light2D>().intensity = 1f;
        }
    }
}
