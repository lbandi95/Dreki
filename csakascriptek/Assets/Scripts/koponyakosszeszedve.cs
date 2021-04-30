using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class koponyakosszeszedve : MonoBehaviour
{    
    public Inventory inventory;
    public GameObject[] itemek;
    public AudioSource audioSource;


    public bool[] megvan;
    void Update()
    {
        
            if(inventory.FindItem(itemek[0])){
                megvan[0]=true;
            }
            if(inventory.FindItem(itemek[1])){
                megvan[1]=true;
            }
            if(inventory.FindItem(itemek[2])){
                megvan[2]=true;
            }
            if(itemek.Length==4){
                if(inventory.FindItem(itemek[3])){
                    megvan[3]=true;
                }
            }
            if(megvan.Length==3){
                if(megvan[0]&&megvan[1]&&megvan[2]){
                    Invoke("ahaSFX", 1f);
                }
            }
            if(megvan.Length==4){
                if(megvan[0]&&megvan[1]&&megvan[2]&&megvan[3]){
                    Invoke("ahaSFX", 1f);
                }
            }
        

    }
    public void ahaSFX(){
        audioSource.enabled=true;
    }
}
