using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadScene("IV_HandTracking");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
