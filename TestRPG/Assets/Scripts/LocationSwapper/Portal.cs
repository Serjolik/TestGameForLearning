using UnityEngine;
using Cinemachine;
public class Portal : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] private Transform PlayerTransform;

    [Header("Distance")]
    [SerializeField] float playerCellRange = 1.7f;

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
        Vector3 newPlayerPosition = PlayerTransform.position;
        switch (portalDirection)
        {
            case (PortalDirection.up):
                newPlayerPosition.y += playerTeleportDistance;
                break;
            case (PortalDirection.down):
                newPlayerPosition.y -= playerTeleportDistance;
                break;
            case (PortalDirection.left):
                newPlayerPosition.x -= playerTeleportDistance;
                break;
            case (PortalDirection.right):
                newPlayerPosition.x += playerTeleportDistance;
                break;
            default:
                return false;
        }
        PlayerTransform.position = newPlayerPosition;
        return true;
    }

    public bool CorrectlyChecker(bool up, bool down, bool left, bool right)
    {
        if (up && down || up && left || up && right ||
            down && left || down && right || left && right)
            return false;
        else
        {
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

}
