using System.Collections;
using UnityEngine;

public class Beat : MonoBehaviour
{
    [Header("ParticleSystem")]
    [SerializeField] private ParticleSystem particles;
    [Header("Variables")]
    [SerializeField] private float hp;
    [SerializeField] private float attack_delay;
    [SerializeField] private string type_of_damage;

    private bool can_attack = true;
    private bool can_be_attacked = true;
    private bool in_player_range;
    private bool in_flashlight_range;

    [HideInInspector] public PlayerStats player;
    [HideInInspector] public PlayerDamage playerDamage;

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
        playerDamage.GetDamage(type_of_damage);
        StartCoroutine(AttackDelay());
    }

    void BeenAttacked()
    {
        hp -= player.AttackDamage();
        StartCoroutine(PlayerAttackDelay());
        if (hp <= 0)
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