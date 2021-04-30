using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Inventory inventory;
    public GameObject koponya1;
    public GameObject koponya2;
    public GameObject koponya3;
    public LevelLoader levelLoader;
    private bool launch;

    private void Update()
    {
        if (launch)
        {
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("input");
                if (inventory.FindItem(koponya1))
                {
                    if (inventory.FindItem(koponya2))
                    {
                        if (inventory.FindItem(koponya3))
                        {
                            Debug.Log("koponyak megtalalva");
                            inventory.DeleteItem(koponya1);
                            inventory.DeleteItem(koponya2);
                            inventory.DeleteItem(koponya3);
                            Debug.Log("koponyak torolve");
                            GameObject.Find("fullkoponya").GetComponent<SpriteRenderer>().enabled=true;
                            //invoke anim ottlesz a koponya
                            Invoke("Loader", 1f);
                            Invoke("LoadEnd", 2f);
                        }
                    }
                }
                else
                {
                    Debug.Log("Koponya hiba");
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name=="Player")
        {
            launch = true;
        }        
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        launch = false;
    }
    public void LoadEnd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Loader()
    {
        levelLoader.LoadNextLevel();
    }
}
