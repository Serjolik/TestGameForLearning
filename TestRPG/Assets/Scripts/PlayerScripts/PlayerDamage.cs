using System.Collections;
using UnityEngine;
using System;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float damageTimeSec = 1f;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private PlayerHpCanvas HpBarScript;
    private SpriteRenderer playerSpriteRenderer;
    private Color DamageColor = Color.red;
    private Color DefaultColor;

    private void Start()
    {
        playerSpriteRenderer = GetComponentInParent<SpriteRenderer>();
        DefaultColor = playerSpriteRenderer.color;
    }

    public void GetDamage(string damage_type)
    {
        var (currentHp, maxHp) = playerStats.HpReturns();
        DamageEffect(maxHp);

        HpBarScript.FillDamageBar(currentHp, maxHp); // Draw translucent past health
        currentHp = playerStats.Damaged(DamageTypeDefinition(damage_type));
        HpBarScript.FillBar(currentHp, maxHp); // Draw now health
    }

    public void DamageEffect(float maxHp)
    {
        StopCoroutine(DamageEffectCoroutine());
        StopCoroutine(DamageHpBarCoroutine(maxHp));
        StartCoroutine(DamageEffectCoroutine());
        StartCoroutine(DamageHpBarCoroutine(maxHp));
    }

    public IEnumerator DamageHpBarCoroutine(float maxHp)
    {
        yield return new WaitForSeconds(damageTimeSec);
        HpBarScript.FillDamageBar(0, maxHp);
    }

    public float DamageTypeDefinition(string damageType)
    {
        float damage = 0;
        switch (damageType)
        {
            case ("light"):
                damage = 1f;
                break;
            case ("heavy"):
                damage = 3f;
                break;
        }
        if (damage == 0)
        {
            Debug.Log("Unknown damage type return 0 damage");
        }
        return damage;
    }
    public IEnumerator DamageEffectCoroutine()
    {
        float time = 0;
        float step = 1f / damageTimeSec;

        while (time < damageTimeSec)
        {
            time += Time.deltaTime;
            playerSpriteRenderer.color = Color.Lerp(DamageColor, DefaultColor, step * time);

            yield return null;
        }
    }
}
