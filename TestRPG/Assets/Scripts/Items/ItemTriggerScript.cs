using UnityEngine;

public class ItemTriggerScript : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerInventory.SlotAdded(gameObject.name, GetComponent<SpriteRenderer>().sprite))
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
