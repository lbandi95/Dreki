using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SzoborTeremScript : MonoBehaviour
{
    private void Update()
    {
        if (GameObject.Find("armor bal felso").GetComponent<ArmorScript>().aktualsprite == 2
            && GameObject.Find("armor jobb felso").GetComponent<ArmorScript>().aktualsprite == 3
            && GameObject.Find("armor bal also").GetComponent<ArmorScript>().aktualsprite == 1
            && GameObject.Find("armor jobb also").GetComponent<ArmorScript>().aktualsprite == 4)
        {
            GameObject.Find("ketrec").GetComponent<Animator>().SetTrigger("Start");
            GameObject.Find("szobrosszilank").GetComponent<CapsuleCollider2D>().enabled = true;
            this.gameObject.GetComponent<SzoborTeremScript>().enabled = false;
        }
    }
}
