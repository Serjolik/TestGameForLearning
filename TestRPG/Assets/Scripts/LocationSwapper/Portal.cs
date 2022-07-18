using UnityEngine;
public class Portal : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private Transform CameraTransform;

    [Header("Distance")]
    [SerializeField] float playerTeleportDistance = 5f;
    [SerializeField] float cameraTeleportDistance = 5f;

    public enum PortalDirection
    {
        up,
        down,
        left,
        right
    }
    PortalDirection portalDirection;

    private bool Move()
    {
        Vector3 newPlayerPosition = PlayerTransform.position;
        Vector3 newCameraPosition = CameraTransform.position;
        switch (portalDirection)
        {
            case (PortalDirection.up):
                newPlayerPosition.y += playerTeleportDistance;
                newCameraPosition.y += cameraTeleportDistance;
                break;
            case (PortalDirection.down):
                newPlayerPosition.y -= playerTeleportDistance;
                newCameraPosition.y -= cameraTeleportDistance;
                break;
            case (PortalDirection.left):
                newPlayerPosition.x -= playerTeleportDistance;
                newCameraPosition.x -= cameraTeleportDistance;
                break;
            case (PortalDirection.right):
                newPlayerPosition.x += playerTeleportDistance;
                newCameraPosition.x += cameraTeleportDistance;
                break;
            default:
                return false;
        }
        PlayerTransform.position = newPlayerPosition;
        CameraTransform.position = newCameraPosition;
        return true;
    }

    public bool CorrectlyChecker(bool up, bool down, bool left, bool right)
    {
        if (up && down || up && left || up && right || down && left ||
            down && right || left && right) return false;
            return true;
    }

    public bool PortalActivated(bool up, bool down, bool left, bool right)
    {
        if (up) portalDirection = PortalDirection.up;
        else if (down) portalDirection = PortalDirection.down;
        else if (left) portalDirection = PortalDirection.left;
        else if (right) portalDirection = PortalDirection.right;
        else
        {
            Debug.Log("You dont set portal position");
            return false;
        }
        return Move();
    }
}
