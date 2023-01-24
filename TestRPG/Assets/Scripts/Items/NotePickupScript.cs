using UnityEngine;
using System.Collections.Generic;

public class NotePickupScript : MonoBehaviour
{
    [SerializeField] private NoteScript noteScript;
    [SerializeField] private string HeaderText;
    [SerializeField] private List<string> NoteText;

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
                    if (noteScript.havePages() > 0)
                        noteScript.SwitchPage();
                    else
                    {
                        CloseNote();
                    }
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
        noteScript.PickupCurrentNote(HeaderText, NoteText, NoteText.Count);
        reading = true;
    }

    private void CloseNote()
    {
        noteScript.CloseCurrentNote();
        reading = false;
    }

}