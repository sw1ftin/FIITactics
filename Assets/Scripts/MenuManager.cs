using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/Game");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Scenes/Tutorial");
    }
        
    public void ExitGame()
    {
        Application.Quit();
    }
}
