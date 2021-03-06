using UnityEngine;
public class LightController : MonoBehaviour
{
    private int angle;
    private string position;
    private static string StartPosition = "IsDown";

    void Start()
    {
        position = StartPosition;
    }
    public void LightTransform(string lastpos)
    {
        if (lastpos == position)
        {
            return;
        }

        switch (lastpos)
        {
            case ("IsUp"):
                angle = 0;
                break;
            case ("IsDown"):
                angle = 180;
                break;
            case ("IsRight"):
                angle = 270;
                break;
            case ("IsLeft"):
                angle = 90;
                break;
            case ("IsUpLeft"):
                angle = 45;
                break;
            case ("IsUpRight"):
                angle = 315;
                break;
            case ("IsDownLeft"):
                angle = 135;
                break;
            case ("IsDownRight"):
                angle = 225;
                break;
        }
        position = lastpos;
        this.transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
