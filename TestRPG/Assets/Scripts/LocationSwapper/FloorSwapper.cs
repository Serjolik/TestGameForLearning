using UnityEngine;

public class FloorSwapper : MonoBehaviour
{
    [SerializeField] private GameObject[] floor;
    private int floorIndex = 0;
    private int floorCount = 0;

    private void Awake()
    {
        floorCount = floor.Length;
    }

    private bool CanSwap(int len)
    {
        return ((floorIndex + len) > 0) && ((floorIndex + len) < floorCount);
    }

    public bool transition(int len)
    {
        if (CanSwap(len))
        {
            floor[floorIndex].SetActive(false);
            floorIndex += len;
            floor[floorIndex].SetActive(true);
            return true;
        }
        else
        {
            Debug.Log("You cannot swap floor, check floors");
            return false;
        }
    }

}
