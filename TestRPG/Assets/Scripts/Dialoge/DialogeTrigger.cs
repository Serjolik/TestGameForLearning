using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogeTrigger : MonoBehaviour
{
    [Header("VisualCue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset InkJSON;

    private bool PlayerCloose;

    private void Awake()
    {
        PlayerCloose = false;
        visualCue.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerCloose = true;
            visualCue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerCloose = false;
            visualCue.SetActive(false);
        }
    }

    void Update()
    {
        if (PlayerCloose && !DialogeManager.GetInstance().dialogeIsPlaying)
        {
            if (Input.GetKey(KeyCode.E))
            {
                DialogeManager.GetInstance().EnterDialogeMode(InkJSON);
            }
        }
    }
}
