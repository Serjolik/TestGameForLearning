using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;

    private int inventorySlotsCount;
    private Sprite EmptySlotSprite;

    private Dictionary<string, Sprite> slotsDict;
    private Image[] images;

    private void Awake()
    {
        images = Inventory.GetComponentsInChildren<Image>();
        inventorySlotsCount = images.Length - 1;
        EmptySlotSprite = images[1].sprite;
        slotsDict = new Dictionary<string, Sprite> { };
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

    private void InventoryCellDraw()
    {
        int index = 0;
        for (int i = 1; i < images.Length; i++)
        {
            images[i].sprite = EmptySlotSprite;
        }
        foreach (Sprite sprite in slotsDict.Values)
        {
            index++;
            images[index].sprite = sprite;
        }
    }

    public bool SlotAdded(string itemName, Sprite sprite)
    {
        if (inventoryIsFull())
        {
            return false;
        }
        slotsDict.Add(itemName, sprite);
        InventoryCellDraw();
        return true;
    }

    public void SlotDeleted(string itemName)
    {
        if (slotsDict.ContainsKey(itemName))
            slotsDict.Remove(itemName);
        else
            Debug.Log("Not contains this item");
        InventoryCellDraw();
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
