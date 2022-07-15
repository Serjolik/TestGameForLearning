using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Does not include buttons on triggers
    [SerializeField] GameObject Menu;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] private PlayerInventory inventory;

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

        if (!menuActive)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement.Normalize();
            playerMovement.MovementSetter(movement);

            if (Input.GetKey(KeyCode.I))
            {
                inventory.Draw(true);
            }
            if (Input.GetKeyUp(KeyCode.I))
            {
                inventory.Draw(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuActive)
            {
                MenuClosed();
            }
            else
            {
                MenuOpen();
                // When Menu open we need to set false inventory drawing
                inventory.Draw(false);
            }
        }
    }
    public void MenuClosed()
    {
        menuActive = false;
        Menu.SetActive(false);
        Time.timeScale = 1;
    }
    private void MenuOpen()
    {
        Menu.SetActive(true);
        menuActive = true;
        Time.timeScale = 0;
    }
}
