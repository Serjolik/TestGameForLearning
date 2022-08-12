using UnityEngine;

public class PortalSettings : MonoBehaviour
{
    [Header("Portal logic script")]
    [SerializeField] private Portal portal;
    [Header("Set one position")]
    [SerializeField] private bool up;
    [SerializeField] private bool down;
    [SerializeField] private bool left;
    [SerializeField] private bool right;
    [Header("Set distance")]
    [SerializeField] private int distance; // distance in cells to the next room

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (portal.CorrectlyChecker(up, down, left, right))
            {
                if (portal.PortalActivated(up, down, left, right, distance))
                {
                    Debug.Log("Teleport works");
                }
                else
                {
                    Debug.Log("Teleport failed");
                }
            }
            else
            {
                Debug.Log("More than ore direction selected, teleport deactivated");
            }
        }
    }
}
