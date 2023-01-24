using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class NoteScript : MonoBehaviour
{
    [SerializeField] private GameObject NotePanel;
    private TMP_Text[] Note;
    private string HeaderText;
    private List<string> NoteText;
    private bool reading = false;
    private int page = 0;
    private int pages = 0;

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

    public void SwitchPage()
    {
        if (page < pages - 1)
        {
            page++;
            Note[1].text = NoteText[page];
        }
    }

    private void SetNoteText()
    {
        Note[0].text = HeaderText;
        Note[1].text = NoteText[0];
    }
    public void PickupCurrentNote(string HeaderText, List<string> NoteText, int pages)
    {
        page = 0;
        this.HeaderText = HeaderText;
        this.NoteText = NoteText;
        this.pages = pages;
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
    public int havePages()
    {
        return pages - (page + 1);
    }
}
