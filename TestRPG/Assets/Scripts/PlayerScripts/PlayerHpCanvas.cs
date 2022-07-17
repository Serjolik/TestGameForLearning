using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHpCanvas : BaseUI
{
    [Header("DamageImage")]
    [SerializeField] private Image HpDamageBar;

    private float hpFill;

    private void Start()
    {
        hpFill = 1f;
        var (playerHp, playerMaxHp) = player.HpReturns();
        TextBoxEdit(playerMaxHp, playerMaxHp);
    }

    public void FillDamageBar(float lastHp, float maxHp)
    {
        hpFill = lastHp / maxHp;
        HpDamageBar.fillAmount = hpFill;
    }
}
