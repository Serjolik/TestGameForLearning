using System;
using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private PlayerHpCanvas HpBarScript;
    [SerializeField] private PlayerDamage playerDamage;
    [Header("Stats")]
    [SerializeField] private float max_hp = 15;
    [SerializeField] private float attack_speed = 5;
    [SerializeField] private float attack_damage = 1;
    [SerializeField] private float regenerationTimer = 10f;
    [SerializeField] private float hpRegeneration = 1f;
    [SerializeField] private float damageTimeSec = 1f;

    private bool is_alive = true;
    private float current_hp;
    private Color DamageColor = Color.red;

    private float damage;
    private Vector3 position;

    private Transform PlayerTransform;
    private SpriteRenderer SpriteRenderer;
    private Color DefaultColor;

    private void Start()
    {
        PlayerTransform = GetComponent<Transform>();
        current_hp = max_hp;
        HpBarScript.StartFillBar(current_hp, max_hp);
    }

    public float Damaged(float damage)
    {
        current_hp -= damage;
        if (current_hp <= 0)
        {
            is_alive = false;
            current_hp = 0;
        }
        else
        {
            Regeneration();
        }
        return current_hp;
    }

    private void Regeneration()
    {
        StopCoroutine(nameof(HpRegenerationCoroutine));
        StartCoroutine(nameof(HpRegenerationCoroutine));
    }

    private IEnumerator HpRegenerationCoroutine()
    {
        yield return new WaitForSeconds(regenerationTimer);
        if (current_hp != max_hp)
        {
            current_hp += hpRegeneration;
            HpBarScript.FillBar(current_hp, max_hp);
            Regeneration();
        }
    }

    public bool PlayerIsAlive()
    {
        return this.is_alive;
    }

    public float AttackSpeed()
    {
        return (1 / this.attack_speed);
    }

    public float AttackDamage()
    {
        return this.attack_damage;
    }

    public Tuple<float, float> HpReturns()
    {
        return Tuple.Create(this.current_hp, this.max_hp);
    }
}
