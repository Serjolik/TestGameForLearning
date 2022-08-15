using UnityEngine;

public class ButtonController : ButtonsHandler
{
    private bool canAct => !(InDialog() || InCutscene() || menuActive);
    void Update()
    {
        if (canAct)
        {
            Movement();
            Inventory();
        }

        if (pauseButton)
        {
            Pause();
        }

    }
    private void Pause()
    {
        if (menuActive)
        {
            MenuClosed();
        }
        else
        {
            MenuOpen();
        }
    }
}
