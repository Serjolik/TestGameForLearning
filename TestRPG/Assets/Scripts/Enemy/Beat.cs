using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    [Header("ParticleSystem")]
    [SerializeField] public ParticleSystem particles;

    [Header("PlayerStats")]
    [SerializeField] public PlayerStats player;

    [SerializeField] public float hp;
    [SerializeField] public float attack_delay;

    [SerializeField] public string type_of_damage;

    private bool can_attack = true;
    private bool can_be_attacked = true;
    private bool in_player_range;
    private bool in_flashlight_range;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            in_player_range = true;
        if (collision.gameObject.tag == "Flashlight")
            in_flashlight_range = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            in_player_range = false;
        if (collision.gameObject.tag == "Flashlight")
            in_flashlight_range = false;
    }

    void Attack()
    {
        player.GetDamage(type_of_damage);
        StartCoroutine(AttackDelay());
    }

    void BeenAttacked()
    {
        this.hp -= player.AttackDamage();
        StartCoroutine(PlayerAttackDelay());
        if (this.hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator AttackDelay()
    {
        can_attack = false;
        yield return new WaitForSeconds(attack_delay);
        can_attack = true;
    }

    private void Start()
    {
        particles.Stop();
    }

    IEnumerator PlayerAttackDelay()
    {
        particles.Play();
        can_be_attacked = false;
        yield return new WaitForSeconds(player.AttackSpeed());
        can_be_attacked = true;
        particles.Stop();
    }

    private void Update()
    {
        if (in_player_range && can_attack)
        {
            Attack();
        }
        if (in_flashlight_range && can_be_attacked)
        {
            BeenAttacked();
        }
    }
}