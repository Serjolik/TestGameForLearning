using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ExitPressed()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }

    public void SettingsPressed()
    {
        Debug.Log("Settings");
    }

}
