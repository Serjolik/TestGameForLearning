using UnityEngine;
using UnityEngine.UI;

public class PlayerHpCanvas : MonoBehaviour
{
    [Header("PlayerStats")]
    [SerializeField] private PlayerStats player;
    [Header("Images")]
    [SerializeField] private Image HpBar;
    [SerializeField] private Image HpDamageBar;
    [SerializeField] private TMPro.TMP_Text textBox;

    private float hpFill;

    private void Start()
    {
        hpFill = 1f;
        HpTextBoxEdit(player.HowMuchHp(), player.MaxHp());
    }

    public void FillBar(float maxHp, float currentHp)
    {
        hpFill = currentHp / maxHp;
        HpBar.fillAmount = hpFill;
        HpTextBoxEdit(maxHp, currentHp);
    }

    public void FillDamageBar(float maxHp, float lastHp)
    {
        hpFill = lastHp / maxHp;
        HpDamageBar.fillAmount = hpFill;
    }

    private void HpTextBoxEdit(float maxHp, float currentHp)
    {
        textBox.text = "Health: " + currentHp.ToString() + "/" + maxHp.ToString();
    }
}
