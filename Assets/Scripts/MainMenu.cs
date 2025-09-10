using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnSpeakPressed()
    {
        SceneManager.LoadScene("TheVoid");
    }

    public void OnPrivacyPressed()
    {
        SceneManager.LoadScene("PrivacyScreen");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
