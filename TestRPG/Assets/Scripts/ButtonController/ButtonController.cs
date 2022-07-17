using UnityEngine;

public class ButtonController : ButtonsHandler
{
    void Update()
    {

        if (InDialog())
        {
            return;
        }

        if (!menuActive)
        {
            Movement();
            Inventory();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
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
