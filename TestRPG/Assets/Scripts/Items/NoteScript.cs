using UnityEngine;
using TMPro;

public class NoteScript : MonoBehaviour
{
    [SerializeField] private GameObject NotePanel;
    private TMP_Text[] Note;
    private string HeaderText;
    private string NoteText;
    private bool reading = false;

    private void Awake()
    {
        Note = NotePanel.GetComponentsInChildren<TMP_Text>();
    }

    private void NotePickup()
    {
        NotePanel.SetActive(true);
        reading = true;
    }

    private void NoteClosed()
    {
        NotePanel.SetActive(false);
        reading = false;
    }
    private void SetNoteText()
    {
        Note[0].text = HeaderText;
        Note[1].text = NoteText;
    }
    public void PickupCurrentNote(string HeaderText, string NoteText)
    {
        this.HeaderText = HeaderText;
        this.NoteText = NoteText;
        SetNoteText();
        NotePickup();
    }
    public void CloseCurrentNote()
    {
        NoteClosed();
    }
    public bool isReading()
    {
        return reading;
    }
}
