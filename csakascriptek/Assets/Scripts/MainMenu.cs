using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    private void Start()
    {
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        transition.SetTrigger("Start");
        Cursor.visible = false;
        Invoke("LoadLevel", 1f);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
