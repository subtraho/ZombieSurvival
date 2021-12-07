using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject startButton;
    public GameObject controlsButton;
    public GameObject quitButton;
    public GameObject controlsPanel;
    public GameObject mainmenuButton;



    public void StartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void ControlsButtonClick()
    {
        startButton.SetActive(false);
        controlsButton.SetActive(false);
        quitButton.SetActive(false);
        controlsPanel.SetActive(true);
        mainmenuButton.SetActive(true);
    }

    public void MainMenuButtonClick()
    {
        startButton.SetActive(true);
        controlsButton.SetActive(true);
        quitButton.SetActive(true);
        controlsPanel.SetActive(false);
        mainmenuButton.SetActive(false);
    }

    public void QuitButtonClick()
    {
        Application.Quit();
    }
}
