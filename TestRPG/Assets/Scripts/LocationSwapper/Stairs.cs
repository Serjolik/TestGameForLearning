using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [Header("Logic script")]
    [SerializeField] StairsLogic stairsLogic;
    [Header("Which way")]
    [SerializeField] private bool up;
    [SerializeField] private bool down;
    [Header("How far")]
    [Header("(not needed if moving to nearby floor)")]
    [SerializeField] private int len;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Move();
        }
    }

    private void Move()
    {
        if (len < 0)
        {
            Debug.Log("Len");
        }
        else if (len <= 1)
        {
            if (stairsLogic.SwitchFloor(up, down))
            {
                return;
            }
            else
            {
                ErrorMessage("stairsLogic.SwitchFloor(up, down)");
            }
        }
        else if (len > 1)
        {
            if (stairsLogic.SwitchFloor(len))
            {
                return;
            }
            else
            {
                ErrorMessage("stairsLogic.SwitchFloor(len)");
            }
        }
        else
        {
            Debug.Log("Not covered part of code, something may changed in code incorrectly");
        }
    }

    private void ErrorMessage(string text)
    {
        Debug.Log("Something went wrong");
        Debug.Log(text + " return Error");
    }
}
