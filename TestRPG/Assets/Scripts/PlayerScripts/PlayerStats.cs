using System;
using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private PlayerHpCanvas HpBarScript;
    [Header("Stats")]
    [SerializeField] private bool is_alive = true;
    [SerializeField] private float max_hp = 15;
    [SerializeField] private float current_hp = 15;
    [SerializeField] private float player_speed = 5;
    [SerializeField] private float attack_speed = 5;
    [SerializeField] private float attack_damage = 1;
    [SerializeField] private Color DamageColor = Color.red;
    [SerializeField] private float DamageTimeSec = 1f;

    private int damage;
    private Vector3 position;

    private Transform PlayerTransform;
    private SpriteRenderer SpriteRenderer;
    private Color DefaultColor;

    private void Start()
    {
        PlayerTransform = GetComponent<Transform>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        DefaultColor = SpriteRenderer.color;
    }

    public void GetDamage(string damage_type)
    {
        switch (damage_type)
        {
            case ("light"):
                damage = 1;
                break;
            case ("heavy"):
                damage = 3;
                break;
            default:
                Debug.Log("Unknow type of damage");
                break;
        }

        HpBarScript.FillDamageBar(max_hp, current_hp);
        this.current_hp -= damage;
        HpBarScript.FillBar(max_hp, current_hp);
        DamageEffect();

        if (this.current_hp <= 0)
        {
            this.is_alive = false;
        }
    }

    private IEnumerator DamageEffectCoroutine()
    {
        float time = 0;
        float step = 1f / DamageTimeSec;

        while (time < DamageTimeSec)
        {
            time += Time.deltaTime;
            SpriteRenderer.color = Color.Lerp(DamageColor, DefaultColor, step * time);

            yield return null;
        }
    }

    private IEnumerator DamageHpBarCoroutine()
    {
        yield return new WaitForSeconds(DamageTimeSec);
        HpBarScript.FillDamageBar(max_hp, 0);
    }

    public void DamageEffect()
    {
        StopCoroutine(nameof(DamageEffectCoroutine));
        StopCoroutine(nameof(DamageHpBarCoroutine));
        StartCoroutine(nameof(DamageEffectCoroutine));
        StartCoroutine(nameof(DamageHpBarCoroutine));
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
