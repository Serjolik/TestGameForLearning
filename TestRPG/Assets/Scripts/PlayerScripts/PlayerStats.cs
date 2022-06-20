using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private bool is_alive;
    [SerializeField] private int max_hp;
    [SerializeField] private int current_hp;
    [SerializeField] private float player_speed;
    [SerializeField] private float attack_speed;
    [SerializeField] private float attack_damage;

    private int damage;
    private Vector3 position;

    private Transform PlayerTransform;
    private SpriteRenderer SpriteRenderer;

    public Color DamageColor = Color.red;
    public float DamageTimeSec = 1f;
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

        this.current_hp -= damage;
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

    public void DamageEffect()
    {
        StopCoroutine(nameof(DamageEffectCoroutine));
        StartCoroutine(nameof(DamageEffectCoroutine));
    }

    public int HowMuchHp()
    {
        return this.current_hp;
    }

    public int MaxHp()
    {
        return this.max_hp;
    }

    public float PlayerSpeed()
    {
        return this.player_speed;
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
    
    public Vector3 PlayerPosition()
    {
        position = this.PlayerTransform.position;
        return this.position;
    }
}
