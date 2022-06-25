using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventory;

    private Dictionary<string, string> slots_dict;
    private KeyValuePair<string, string> slot;

    public void SlotAdded(string itemName, string itemAbility)
    {
        if (!inventoryIsFull())
        {
            return;
        }
        slots_dict.Add(itemName, itemAbility);
    }

    public void Draw(bool active)
    {
        inventory.SetActive(active);
    }

    private bool inventoryIsFull()
    {
        if(slots_dict.Count < 7)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
