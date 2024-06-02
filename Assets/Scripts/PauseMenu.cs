using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isOpen;

    public GameObject PauseMenuGameObject;
    public GameObject Canvas;

    public void OpenPauseMenu()
    {
        isOpen = !isOpen;
        PauseMenuGameObject.SetActive(isOpen);
        Canvas.SetActive(!isOpen);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Scenes/Game");
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Scenes/Main Menu");
    }
}