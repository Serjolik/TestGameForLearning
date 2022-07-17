using UnityEngine;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour
{
    [Header("PlayerStats")]
    public PlayerStats player;
    [Header("Objects")]
    public Image imageBar;
    public TMPro.TMP_Text textBox;

    private float fill = 1f;
    public virtual void FillBar(float param, float maxParam)
    {
        fill = param / maxParam;
        imageBar.fillAmount = fill;
        TextBoxEdit(param, maxParam);
    }

    public virtual void TextBoxEdit(float param, float maxParam)
    {
        textBox.text = "Health: " + param.ToString() + "/" + maxParam.ToString();
    }

}
