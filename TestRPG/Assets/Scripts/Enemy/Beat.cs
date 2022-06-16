using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    [SerializeField] public int hp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Beatfunk();
    }

    void Beatfunk()
    {
        Debug.Log("Beat!");
        hp--;
    }
}