using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenuScript : MonoBehaviour
{
    [SerializeField] ButtonController buttonController;
    public void ContinuePressed()
    {
        buttonController.MenuClosed();
        Debug.Log("Continue pressed");
    }
    public void SettingsPressed()
    {
        Debug.Log("Settings");
    }
    public void ReturnToMenuPressed()
    {
        Debug.Log("Return to menu");
        buttonController.MenuClosed();
        SceneManager.LoadScene("Menu");
    }
}
