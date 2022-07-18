using UnityEngine;

public class ButtonsHandler : MonoBehaviour
{
    // Does not include buttons on triggers
    [SerializeField] GameObject Menu;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private PlayerStamina playerStamina;

    private bool isRun => movement != Vector2.zero && Input.GetKey(KeyCode.LeftShift);
    private bool isStop => movement == Vector2.zero;

    protected Vector2 movement;
    protected bool menuActive = false;

    public void MenuClosed()
    {
        menuActive = false;
        Menu.SetActive(false);
        Time.timeScale = 1;
    }
    protected void MenuOpen()
    {
        Menu.SetActive(true);
        menuActive = true;
        Time.timeScale = 0;
        // When Menu open we need to set false inventory drawing
        inventory.Draw(false);
    }

    private Vector2 GetMovingButtonsPressed()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        return movement;
    }

    protected void Movement()
    {
        if (isRun)
        {
            float stamina = playerStamina.Stamina();
            if (stamina > 0)
            {
                playerStamina.Stamina(-0.01f);
                playerMovement.SwitchToRun();
            }
            else
            {
                playerMovement.SwitchToWalk();
            }
        }
        else if (!isStop)
        {
            playerMovement.SwitchToWalk();
        }
        else
        {
            playerMovement.SwitchToStay();
            playerStamina.Rest();
        }
        playerMovement.MovementSetter(GetMovingButtonsPressed());
    }

    private void StopMoving()
    {
        playerMovement.SwitchToStay();
        playerStamina.Rest();
        playerMovement.MovementSetter(Vector2.zero);
    }

    protected void Inventory()
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

    protected bool InDialog()
    {
        if (DialogeManager.GetInstance().dialogeIsPlaying)
        {
            StopMoving();
            if (Input.anyKeyDown)
            {
                DialogeManager.GetInstance().continueStory();
            }
            return true;
        }
        return false;
    }

}
