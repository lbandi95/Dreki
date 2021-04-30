using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxbe : MonoBehaviour
{
    public GameObject parallax;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        parallax.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        parallax.SetActive(false);
    }
}
