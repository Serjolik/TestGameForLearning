using UnityEngine;
using UnityEngine.UI;

public class PlayerHpCanvas : BaseUI
{
    [Header("DamageImage")]
    [SerializeField] private Image HpDamageBar;

    private float hpFill;

    public void StartFillBar(float hp, float maxHp)
    {
        hpFill = 1f;
        TextBoxEdit(hp, maxHp);
    }

    public void FillDamageBar(float lastHp, float maxHp)
    {
        hpFill = lastHp / maxHp;
        HpDamageBar.fillAmount = hpFill;
    }
}
