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
        TextBoxEdit(playerHp, playerMaxHp);
    }

    public void FillDamageBar(float maxHp, float lastHp)
    {
        hpFill = lastHp / maxHp;
        HpDamageBar.fillAmount = hpFill;
    }
}
