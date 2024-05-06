using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialButton : MonoBehaviour
{
    public void OpenTutorial()
    {
        SceneManager.LoadScene("Scenes/Tutorial");
    }
}