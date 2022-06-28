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

    private Dictionary<string, int> imageId;

    private void Start()
    {
        images = Inventory.GetComponentsInChildren<Image>();
        slotsDict = new Dictionary<string, string> { };

        /*
         * IN SPRITES:
         * On the 1 slot is a silver key sprite
         */
        imageId = new Dictionary<string, int>
        {
            { "Silver key", 1 }
        };
    }

    private bool inventoryIsFull()
    {
        if (slotsDict.Count < 7)
        {
            return false;
        }
        else
        {
            Debug.Log("Inventory is full");
            return true;
        }
    }
    private void InventoryPic(string itemName)
    {
        index++;
        if (itemName == "Silver key")
        {
            images[index].sprite = Sprites[imageId["Silver key"]];
        }
        else
        {
            Debug.Log("We dont have this Sprite, please check Sprite name");
        }
    }
    public bool SlotAdded(string itemName, string itemAbility)
    {
        if (inventoryIsFull())
        {
            return false;
        }
        InventoryPic(itemName);
        slotsDict.Add(itemName, itemAbility);
        return true;
    }

    public void Draw(bool active)
    {
        Inventory.SetActive(active);
    }
}
