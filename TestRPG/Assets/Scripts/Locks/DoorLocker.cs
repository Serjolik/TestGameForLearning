using UnityEngine;

public class DoorLocker : MonoBehaviour
{
    [SerializeField] protected PlayerInventory playerInventory;
    [SerializeField] protected GameObject requiredKey;
    protected string requiredKeyName;

    private void Awake()
    {
        requiredKeyName = requiredKey.name;
    }

    protected void Unlocked()
    {
        playerInventory.SlotDeleted(requiredKeyName);
        gameObject.SetActive(false);
    }

    protected void Locked()
    {
        Debug.Log("This door is locked, you need key");
    }
}
