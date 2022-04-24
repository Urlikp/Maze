using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public float maxStamina = 100;
    public float currentStamina;
    public float staminaRegenTime;


    bool modifyHealthReq;
    bool modifyStaminaReq;
    public HealthBar healthBar;
    public StaminaBar staminaBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        healthBar.SetMaxHealth(maxHealth);
        staminaBar.SetMaxStamina(maxStamina);
    }

    //Stamina regen
    void FixedUpdate()
    {

        if (staminaRegenTime > 1000f) staminaRegenTime = 1f;
        staminaRegenTime += Time.deltaTime;

        if (staminaRegenTime >= 1f) 
        {
            ModifyStamina(0.25f);
        }
      
    }

    //Modifies player health
    public void ModifyHealth(float value)
    {
        currentHealth += value;
        if (currentHealth > 100) currentHealth = 100;
        if (currentHealth < 0) currentHealth = 0;
        healthBar.SetHealth(currentHealth);
    }

    //Modifies player stamina
    public void ModifyStamina(float value)
    {
        if(value < 0) staminaRegenTime = 0f;
        if (currentStamina + value <= 100 && currentStamina + value >= 0)
        {
            currentStamina += value;
            staminaBar.SetStamina(currentStamina);
        }
    }

    //Sets player health to a certain value
    public void SetHealth(float value)
    {
        currentHealth = value;
        healthBar.SetHealth(currentHealth);
    }

    //Sets player stamina to a certain value
    public void SetStamina(float value)
    {
        currentStamina = value;
        staminaBar.SetStamina(currentStamina);
    }
}
