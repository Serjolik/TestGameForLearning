using UnityEngine;

public class NotePickupScript : MonoBehaviour
{
    [SerializeField] private NoteScript noteScript;
    [SerializeField] private string HeaderText;
    [SerializeField] private string NoteText;

    private bool reading = false;
    private bool inRange = false;

    private void Update()
    {
        if (inRange)
        {
            if (!reading)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ReadNote();
                }
                return;
            }
            else
            {
                if (Input.anyKeyDown)
                    CloseNote();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }

    private void ReadNote()
    {
        noteScript.PickupCurrentNote(HeaderText, NoteText);
        reading = true;
    }

    private void CloseNote()
    {
        noteScript.CloseCurrentNote();
        reading = false;
    }

}