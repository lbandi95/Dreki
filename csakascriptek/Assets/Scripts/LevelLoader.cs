using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public void LoadNextLevel()
    {
        transition.SetTrigger("Start");
    }
}
