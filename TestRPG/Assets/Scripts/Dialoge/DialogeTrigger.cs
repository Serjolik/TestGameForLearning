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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerCloose = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCloose && !DialogeManager.GetInstance().dialogeIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                DialogeManager.GetInstance().EnterDialogeMode(InkJSON);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
}
