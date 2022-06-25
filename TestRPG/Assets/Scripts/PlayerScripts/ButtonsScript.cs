using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;

    private bool keyIsPressed = false;

    void Update()
    {
        if (Input.anyKey || keyIsPressed)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                keyIsPressed = true;
                inventory.Draw(true);
            }
            if (Input.GetKeyUp(KeyCode.I))
            {
                keyIsPressed = false;
                inventory.Draw(false);
            }
        }
    }
}
