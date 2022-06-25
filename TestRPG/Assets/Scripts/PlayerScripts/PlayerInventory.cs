using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;
    [SerializeField] private Sprite[] Sprites;

    private Dictionary<string, string> slotsDict;
    private KeyValuePair<string, string> slot;
    private Image[] images;
    private int index = 0;
    private void Start()
    {
        images = Inventory.GetComponentsInChildren<Image>();
        foreach (var im in images)
        {
            index++;
            if (Sprites.Length > index)
            {
                im.sprite = Sprites[index];
            }
        }
    }

    public void SlotAdded(string itemName, string itemAbility)
    {
        if (!inventoryIsFull())
        {
            return;
        }
        slotsDict.Add(itemName, itemAbility);
    }

    public void Draw(bool active)
    {
        Inventory.SetActive(active);
    }

    private bool inventoryIsFull()
    {
        if(slotsDict.Count < 7)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
