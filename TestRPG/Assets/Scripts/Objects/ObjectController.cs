using UnityEngine;

public class ObjectController : MonoBehaviour
{
    protected bool isInteractable = true;
    protected Vector3 position;

    private void Start()
    {
        position = transform.position;
    }

    protected void StateSwitcher(bool state)
    {
        isInteractable = state;
    }
}
