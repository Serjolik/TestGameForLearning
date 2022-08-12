using Cinemachine;
using UnityEngine;

public class FloorSwapper : MonoBehaviour
{
    [SerializeField] private GameObject[] floor;
    [SerializeField] private GameObject Player;
    [SerializeField] private CinemachineVirtualCamera vCam1;
    [SerializeField] private float distanceToNextScene_x = 100f;
    private int floorIndex = 0;
    private int floorCount = 0;

    private void Awake()
    {
        floorCount = floor.Length;
    }

    private bool CanSwap(int floorNumber)
    {
        return (floorNumber > 0) && (floorNumber < floorCount);
    }

    public bool Transition(int len)
    {
        if (CanSwap(floorIndex + len))
        {
            Move(len);
            floorIndex += len;
            return true;
        }
        else
        {
            return ErrorMessage();
        }
    }

    public bool TransitionToCurrentFloor(int floorNumber)
    {
        if (CanSwap(floorNumber))
        {
            Move(floorNumber - floorIndex);
            floorIndex = floorNumber;
            return true;
        }
        else
        {
            return ErrorMessage();
        }
    }

    private void Move(float value)
    {
        Player.transform.position += new Vector3(distanceToNextScene_x * value, 0, 0);
        vCam1.OnTargetObjectWarped(Player.transform, new Vector3(distanceToNextScene_x * value, 0, 0));
    }

    private bool ErrorMessage()
    {
        Debug.Log("You cannot swap floor to this value, check floors and numbers");
        return false;
    }

}
