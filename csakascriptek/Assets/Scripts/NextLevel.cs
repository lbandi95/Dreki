using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Animator transition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transition.SetTrigger("Start");
        Invoke("LoadNext", 1f);
    }
    void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
