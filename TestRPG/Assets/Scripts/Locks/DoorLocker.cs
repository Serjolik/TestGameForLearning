using UnityEngine;

public class DoorLocker : Lock
{
    protected override void Unlocked()
    {
        Debug.Log("Door Open");
        gameObject.SetActive(false);
    }
    protected override void Locked()
    {
        Debug.Log("This door is locked, you need key");
    }
}
