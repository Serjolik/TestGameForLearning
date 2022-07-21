using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : DoorLocker
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerInventory.ItemSearch(requiredKeyName))
            {
                Unlocked();
            }
            else
            {
                Locked();
            }
        }
    }
}
