using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Does not include buttons on triggers
    [SerializeField] GameObject Menu;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private PlayerStats playerStats;

    private Vector2 movement;
    private bool menuActive = false;
    private bool pant = false;
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
            Movement();
            Inventory();
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

    private void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        if (movement != Vector2.zero && Input.GetKey(KeyCode.LeftShift))
        {
            if (playerStats.playerStamina() > 0 && !pant)
            {
                playerStats.playerStamina(-0.01f);
                playerMovement.SwitchToRun();
            }
            else if (playerStats.playerStamina() <= 0 && !pant)
            {
                pant = true;
                playerMovement.SwitchToWalk();
            }
            else
            {
                playerMovement.SwitchToWalk();
            }
        }
        else if (movement != Vector2.zero)
        {
            playerMovement.SwitchToWalk();
        }
        else
        {
            pant = false;
            playerMovement.SwitchToStay();
            playerStats.Rest();
        }
        playerMovement.MovementSetter(movement);
    }

    private void Inventory()
    {
        if (Input.GetKey(KeyCode.I))
        {
            inventory.Draw(true);
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            inventory.Draw(false);
        }
    }
}
