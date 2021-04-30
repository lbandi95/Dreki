using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectPlayer : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = player.GetComponent<SpriteRenderer>().sprite;
    }
}
