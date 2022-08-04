using UnityEngine;
public class Portal : MonoBehaviour
{
    [SerializeField] private FloorSwapper floorSwapper;

    [Header("Transforms")]
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private Transform CameraTransform;

    [Header("Distance")]
    [SerializeField] float playerCellRange = 1.7f;
    [SerializeField] float cameraCellRange = 2.8f;

    public enum PortalDirection
    {
        up,
        down,
        left,
        right
    }
    PortalDirection portalDirection;

    private bool Move(int distance)
    {
        float playerTeleportDistance = playerCellRange * distance + 0.5f;
        float cameraTeleportDistance = cameraCellRange * distance + 0.5f;
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

    public bool CorrectlyChecker(bool up, bool down, bool left, bool right, bool isTransition)
    {
        if (!isTransition)
        {
            if (up && down || up && left || up && right ||
                down && left || down && right || left && right)
                return false;
            return true;
        }
        else
        {
            if (up && down)
                return false;
            return true;
        }
    }

    public bool PortalActivated(bool up, bool down, bool left, bool right, int distance)
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
        return Move(distance);
    }

    public bool PortalActivated(bool up, bool down)
    {
        int len = 0;
        if (up) len = 1;
        else if (down) len = -1;
        return floorSwapper.transition(len);
    }

}
