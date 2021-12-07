using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void MainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
