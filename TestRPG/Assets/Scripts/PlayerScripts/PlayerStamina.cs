using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private PlayerStaminaCanvas StaminaBarScript;
    [SerializeField] private float fullStamina = 10f;
    [SerializeField] private float staminaRegenetaionSpeed = 0.01f;
    private float stamina;
    private bool isStaminaRegenerationNow;

    private void Awake()
    {
        stamina = fullStamina;
    }
    public void StaminaValidation()
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
    public float Stamina()
    {
        return stamina;
    }

    public void Stamina(float staminaChange)
    {
        stamina += staminaChange;
        StaminaValidation();
        StaminaBarScript.FillBar(stamina, fullStamina);
    }

    private IEnumerator StaminaRegeneration()
    {
        isStaminaRegenerationNow = true;
        yield return new WaitForSeconds(staminaRegenetaionSpeed);
        Stamina(0.01f);
        isStaminaRegenerationNow = false;
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
}
