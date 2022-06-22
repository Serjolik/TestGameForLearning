using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    Resolution[] rsl;
    List<string> resolutions;
    public TMPro.TMP_Dropdown dropdown;
    private bool isFullScreen = true;

    public void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }


}
