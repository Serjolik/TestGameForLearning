using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;

    private int inventorySlotsCount;
    private Sprite EmptySlotSprite;

    private Dictionary<string, string> slotsDict;
    private Image[] images;
    private int index = 0;

    private void Awake()
    {
        images = Inventory.GetComponentsInChildren<Image>();
        inventorySlotsCount = images.Length - 1;
        EmptySlotSprite = images[1].sprite;
        slotsDict = new Dictionary<string, string> { };
    }

    private bool inventoryIsFull()
    {
        if (slotsDict.Count < inventorySlotsCount)
        {
            return false;
        }
        else
        {
            Debug.Log("Inventory is full");
            return true;
        }
    }
    private void InventoryPic(Sprite sprite, int index)
    {
        images[index].sprite = sprite;
    }
    public bool SlotAdded(string itemName, string itemAbility, Sprite sprite)
    {
        if (inventoryIsFull())
        {
            return false;
        }
        InventoryPic(sprite, ++index);
        slotsDict.Add(itemName, itemAbility);
        return true;
    }

    public void SlotDeleted(string itemName)
    {
        int slotIndex = 0;
        foreach (string slotName in slotsDict.Keys)
        {
            slotIndex++;
            if (slotName == itemName)
            {
                images[slotIndex].sprite = EmptySlotSprite;
                break;
            }
        }
        slotsDict.Remove(itemName);
    }

    public bool ItemSearch(string itemName)
    {
        return slotsDict.ContainsKey(itemName);
    }

    public void Draw(bool active)
    {
        Inventory.SetActive(active);
    }
}
