using UnityEngine;

public class ItemTriggerScript : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;

    [SerializeField] private string itemName;
    [SerializeField] private string itemAbility;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerInventory.SlotAdded(itemName, itemAbility, GetComponent<SpriteRenderer>().sprite))
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Slot cant added");
            }
        }
    }
}
