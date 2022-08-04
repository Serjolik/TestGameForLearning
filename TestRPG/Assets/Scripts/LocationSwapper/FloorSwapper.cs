using UnityEngine;

public class FloorSwapper : ScriptableObject
{
    [SerializeField] private GameObject[] floor;
    private int floorIndex = 0;
    private int floorCount = 0;

    private static FloorSwapper instance;
    public static FloorSwapper Instance
    {
        get
        {
            if (instance == null)
            {
                instance = CreateInstance<FloorSwapper>();
            }
            return instance;
        }
    }

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
