using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    [Header("PlayerStats")]
    [SerializeField] public PlayerStats player;

    [SerializeField] public int hp;
    [SerializeField] public float attack_delay;

    [SerializeField] public string type_of_damage;

    private bool can_attack = true;
    private bool in_range;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            in_range = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            in_range = false;
    }

    void Attack()
    {
        player.GetDamage(type_of_damage);
        StartCoroutine(AttackDelay());
    }

    void BeenAttacked()
    {
        this.hp--;
    }

    IEnumerator AttackDelay()
    {
        can_attack = false;
        yield return new WaitForSeconds(attack_delay);
        can_attack = true;
    }

    private void Update()
    {
        if (!in_range || !can_attack)
        {
            return;
        }
        Attack();
    }
}