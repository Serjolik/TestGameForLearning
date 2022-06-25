using System.Collections.Generic;
using UnityEngine;

public class ItemTriggerScript : MonoBehaviour
{
    private GameObject Item;

    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private KeyValuePair<string, string> slot;

    private void Start()
    {
        Item = gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInventory.SlotAdded(slot.Key, slot.Value);
            Destroy(Item);
        }
    }
}
