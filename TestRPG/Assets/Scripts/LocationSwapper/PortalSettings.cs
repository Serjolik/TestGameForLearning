using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSettings : MonoBehaviour
{
    [Header("Set one position")]
    [SerializeField] private bool up;
    [SerializeField] private bool down;
    [SerializeField] private bool left;
    [SerializeField] private bool right;

    private Portal portal;

    private void Awake()
    {
        portal = GetComponentInParent<Portal>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (portal.CorrectlyChecker(up, down, left, right))
            {
                if (portal.PortalActivated(up, down, left, right))
                {
                    Debug.Log("Teleport works");
                }
                else
                {
                    Debug.Log("Teleport failed");
                }
            }
            else
            {
                Debug.Log("More than ore direction selected, teleport deactivated");
            }
        }
    }
}
