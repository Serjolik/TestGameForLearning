using System.Collections;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogeManager : MonoBehaviour
{

    [Header("DialogeUI")]
    [SerializeField] private GameObject dialogePanel;
    [SerializeField] private TextMeshProUGUI dialogeText;

    [Header("TextWritingSpeed")]
    [SerializeField] private float textWriterSpeed;

    private Story currentStory;

    private bool isTalking;

    private string buffer;

    private static DialogeManager instance;
    public bool dialogeIsPlaying { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found More Than One");
        }
        instance = this;
    }

    public static DialogeManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogeIsPlaying = false;
        dialogePanel.SetActive(false);
    }

    public void EnterDialogeMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogeIsPlaying = true;
        dialogePanel.SetActive(true);

        continueStory();
    }

    private IEnumerator ExitDialogeMode()
    {

        yield return new WaitForSeconds(0.2f);

        dialogeIsPlaying = false;
        dialogePanel.SetActive(false);
        dialogeText.text = "";
    }

    public void continueStory()
    {
        if (isTalking)
        {
            dialogeText.text = buffer;
            StopAllCoroutines();
            isTalking = false;
        }
        else if (currentStory.canContinue)
        {
            buffer = currentStory.Continue();
            StopAllCoroutines();
            isTalking = true;
            StartCoroutine(textWriter(buffer));
        }
        else
        {
            StartCoroutine(ExitDialogeMode());
        }
    }

    private IEnumerator textWriter(string buffer)
    {
        dialogeText.text = "";
        foreach (char bufferReader in buffer.ToCharArray())
        {
            dialogeText.text += bufferReader;
            yield return new WaitForSeconds(textWriterSpeed);
        }
        isTalking = false;

    }
}