using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialButtons : MonoBehaviour
{
    public Image Screenshot;
    public static int imageId;
    public static int tutorialImagesCount = 2;
    public Text Steps;

    public void NextImage()
    {
        if (imageId < tutorialImagesCount - 1)
        {
            imageId++;
            UpdateImage();
        }
    }

    public void PrevImage()
    {
        if (imageId > 0)
        {
            imageId--;
            UpdateImage();
        }
    }

    public void UpdateImage()
    {
        var newImage = Resources.Load<Sprite>($"Tutorial/{imageId}");
        Screenshot.sprite = newImage;

        Steps.text = $"{imageId + 1} / {tutorialImagesCount}";
    }

    public void ExitTutorial()
    {
        SceneManager.LoadScene("Scenes/Main Menu");
    }

    private void Start()
    {
        UpdateImage();
    }
}