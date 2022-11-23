using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private GameObject timeline;
    private bool inCutscene = false;

    private void Start()
    {

    }

    public void CutsceneStateSetter(bool state)
    {
        inCutscene = state;
    }

    public bool InCutscene()
    {
        return inCutscene;
    }

}
