using UnityEngine;

public class PortalSettings : MonoBehaviour
{
    [Header("Set one position")]
    [SerializeField] private bool up;
    [SerializeField] private bool down;
    [SerializeField] private bool left;
    [SerializeField] private bool right;
    [SerializeField] private bool isTransition;
    [Header("Set distance")]
    [SerializeField] private int distance;

    private Portal portal;

    private void Awake()
    {
        portal = GetComponentInParent<Portal>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (portal.CorrectlyChecker(up, down, left, right, isTransition))
            {
                if (!isTransition)
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
                    portal.PortalActivated(up, down);
                }
            }
            else
            {
                Debug.Log("More than ore direction selected, teleport deactivated");
            }
        }
    }
}
