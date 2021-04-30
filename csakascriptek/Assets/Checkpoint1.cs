using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint1 : MonoBehaviour
{
    public GameObject wasd;
    public GameObject tobbi;

    private void OnTriggerEnter2D(Collider2D other) {
        wasd.SetActive(false);
        tobbi.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other) {
        tobbi.SetActive(false);
    }
}
