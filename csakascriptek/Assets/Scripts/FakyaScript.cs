using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FakyaScript : MonoBehaviour
{
    public Material alapMaterial;
    public Material faklyasMaterial;
    public GameObject faklyaFoldon;
    public GameObject playerFeny;
       
    private void Update() 
    {       
        if(faklyaFoldon!=null&&faklyaFoldon.GetComponent<FaklyaKi>().mehete){
            //Debug.Log("megkozelitetted a faklyat");     
            Debug.Log("Megprobaltad felvenni a faklyat");
            //GameObject.Find("faklya").GetComponent<SpriteRenderer>().enabled=false;
            Destroy(faklyaFoldon);
            Invoke("FaklyaFelvesz", 1f);          
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        DungeonElhagy();   
    }
    private void FaklyaFelvesz()
    {
        GameObject.Find("Player").GetComponent<Animator>().SetBool("Faklya", true);
        GameObject.Find("Playerfeny").GetComponent<Light2D>().enabled = true;
        GameObject.Find("Player").GetComponent<SpriteRenderer>().material=faklyasMaterial;
        
        GameObject.Find("labirintusajto").GetComponent<Animator>().SetTrigger("close");
        GameObject.Find("labirintusajto").GetComponent<AudioSource>().Play();
        InvokeRepeating("FenyRandomizalo", 0.2f, 0.15f);
        Debug.Log("faklya felveve fakyee");
        GameObject.Find("Faklyagyujt").GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().Play();
    }
    private void DungeonElhagy()
    {
        GameObject.Find("Player").GetComponent<Animator>().SetBool("Faklya", false);
        GameObject.Find("Player").GetComponent<SpriteRenderer>().material=alapMaterial;
        GameObject.Find("Playerfeny").GetComponent<Light2D>().enabled = false;
        GetComponent<AudioSource>().Stop();

    }
    private void FenyRandomizalo()
    {
        playerFeny.GetComponent<Light2D>().pointLightOuterRadius=Random.Range(4.80f, 5.65f);
        playerFeny.GetComponent<Light2D>().intensity=Random.Range(1.00f, 1.20f);
    }
}
