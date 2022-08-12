using UnityEngine;

public class StairsLogic : MonoBehaviour
{
    private FloorSwapper floorSwapper;
    private void Awake()
    {
        floorSwapper = GetComponentInParent<FloorSwapper>();
    }
    public bool SwitchFloor(bool up, bool down)
    {
        if (up)
        {
            return floorSwapper.Transition(1);
        }
        else if (down)
        {
            return floorSwapper.Transition(-1);
        }
        else
        {
            Debug.Log("Cannot switch without set direction");
            return false;
        }
    }

    public bool SwitchFloor(int floorNumber)
    {
        return floorSwapper.TransitionToCurrentFloor(floorNumber);
    }
}
