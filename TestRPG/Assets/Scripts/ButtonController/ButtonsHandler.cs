using UnityEngine;

public class ButtonsHandler : MonoBehaviour
{
    // Does not include buttons on triggers
    [SerializeField] GameObject Menu;
    [Header("Scripts")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private PlayerStamina playerStamina;
    [SerializeField] private BlackScreenAnim blackScreenAnim;
    [SerializeField] private NoteScript noteScript;

    private bool isRun => movement != Vector2.zero && Input.GetKey(KeyCode.LeftShift);
    private bool isStop => movement == Vector2.zero;
    protected bool pauseButton => Input.GetKeyDown(KeyCode.Escape);

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
                Running();
            }
            else
            {
                Walking();
            }
        }
        else if (!isStop)
        {
            Walking();
        }
        else
        {
            Staying();
        }
        playerMovement.MovementSetter(GetMovingButtonsPressed());
    }

    private void StopMoving()
    {
        Staying();
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

    protected bool InReading()
    {
        if (DialogeManager.GetInstance().dialogeIsPlaying)
        {
            // When dialog playing we need to set false inventory drawing and stop moving
            inventory.Draw(false);
            StopMoving();
            // Continue story
            if (Input.anyKeyDown != pauseButton)
            {
                DialogeManager.GetInstance().continueStory();
            }
            return true;
        }
        else if (noteScript.isReading())
        {
            // When we reading need to set false inventory drawing and stop moving
            inventory.Draw(false);
            StopMoving();
            return true;
        }
        return false;
    }

    protected bool InCutscene()
    {
        if (blackScreenAnim.giveInCutsceneState())
            return true;
        return false;
    }

    private void Running()
    {
        playerStamina.Stamina(-0.01f);
        playerMovement.SwitchToRun();
    }

    private void Walking()
    {
        playerMovement.SwitchToWalk();
        playerStamina.WalkingRest();
    }
    private void Staying()
    {
        playerMovement.SwitchToStay();
        playerStamina.Rest();
    }

}
