using Mediapipe.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public WebCamSource webCamSource;
    void Start()
    {
        if (webCamSource != null)
        {
            webCamSource.PauseCamera();
        }
    }

    public void Playgame()
    {
        SceneManager.LoadScene("IV_HandTracking");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

}
