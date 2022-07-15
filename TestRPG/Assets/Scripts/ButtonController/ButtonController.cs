using UnityEngine;

public class ButtonController : MonoBehaviour
{
    //Does not include buttons on triggers
    [SerializeField] GameObject Menu;
    [SerializeField] PlayerMovement playerMovement;

    private Vector2 movement;
    private bool menuActive = false;
    void Update()
    {

        if (DialogeManager.GetInstance().dialogeIsPlaying)
        {
            if (Input.anyKeyDown)
            {
                DialogeManager.GetInstance().continueStory();
            }
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        playerMovement.MovementSetter(movement);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuActive)
            {
                menuActive = false;
                Menu.SetActive(false);
            }
            else
            {
                Menu.SetActive(true);
                menuActive = true;
            }
        }
    }
    public void MenuClosed()
    {
        menuActive = false;
        Menu.SetActive(false);
    }
}
