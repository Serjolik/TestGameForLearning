using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] protected PlayerInventory playerInventory;
    [SerializeField] protected GameObject requiredKey;
    protected string requiredKeyName;

    private void Awake()
    {
        requiredKeyName = requiredKey.name;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Checker();
        }
    }

    private void Checker()
    {
        if (playerInventory.SlotDeleted(requiredKeyName))
        {
            Unlocked();
        }
        else
        {
            Locked();
        }
    }

    protected virtual void Unlocked()
    {
        Debug.Log("This object is unlocked");
    }

    protected virtual void Locked()
    {
        Debug.Log("This object is locked, you need key");
    }

}
