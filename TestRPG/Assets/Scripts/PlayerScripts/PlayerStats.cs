using System;
using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private PlayerHpCanvas HpBarScript;
    [SerializeField] private PlayerStaminaCanvas StaminaBarScript;
    [Header("Stats")]
    [SerializeField] private float max_hp = 15;
    [SerializeField] private float attack_speed = 5;
    [SerializeField] private float attack_damage = 1;
    [SerializeField] private float damageTimeSec = 1f;
    [SerializeField] private float regenerationTimer = 10f;
    [SerializeField] private float hpRegeneration = 1f;
    [SerializeField] private float fullStamina = 10f;
    [SerializeField] private float staminaRegenetaionSpeed = 0.01f;

    private bool is_alive = true;
    private float current_hp;
    private Color DamageColor = Color.red;

    private float stamina;
    private bool isStaminaRegenerationNow;

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
        stamina = fullStamina;
        current_hp = max_hp;
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

        HpBarScript.FillDamageBar(current_hp, max_hp);
        this.current_hp -= damage;

        Regeneration();

        HpBarScript.FillBar(current_hp, max_hp);
        DamageEffect();

        if (this.current_hp <= 0)
        {
            this.is_alive = false;
        }
    }

    private IEnumerator DamageEffectCoroutine()
    {
        float time = 0;
        float step = 1f / damageTimeSec;

        while (time < damageTimeSec)
        {
            time += Time.deltaTime;
            SpriteRenderer.color = Color.Lerp(DamageColor, DefaultColor, step * time);

            yield return null;
        }
    }

    private IEnumerator DamageHpBarCoroutine()
    {
        yield return new WaitForSeconds(damageTimeSec);
        HpBarScript.FillDamageBar(0, max_hp);
    }

    public void DamageEffect()
    {
        StopCoroutine(nameof(DamageEffectCoroutine));
        StopCoroutine(nameof(DamageHpBarCoroutine));
        StartCoroutine(nameof(DamageEffectCoroutine));
        StartCoroutine(nameof(DamageHpBarCoroutine));
    }

    private void Regeneration()
    {
        StopCoroutine(nameof(HpRegenerationCoroutine));
        StartCoroutine(nameof(HpRegenerationCoroutine));
    }

    public void Rest()
    {
        if (stamina < fullStamina)
        {
            if (!isStaminaRegenerationNow)
            {
                StartCoroutine(StaminaRegeneration());
            }
        }
    }

    private IEnumerator StaminaRegeneration()
    {
        isStaminaRegenerationNow = true;
        yield return new WaitForSeconds(staminaRegenetaionSpeed);
        playerStamina(0.01f);
        isStaminaRegenerationNow = false;
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

    public float playerStamina()
    {
        return stamina;
    }

    public void playerStamina(float staminaChange)
    {
        stamina += staminaChange;
        StaminaValidation();
        StaminaBarScript.FillBar(stamina, fullStamina);
    }

    private void StaminaValidation()
    {
        if (stamina > fullStamina)
        {
            stamina = fullStamina;
            Debug.Log("stamina > full stamina, stamina set to full");
        }
        else if (stamina < 0)
        {
            stamina = 0;
            Debug.Log("stamina < 0, stamina set to 0");
        }
    }

}
