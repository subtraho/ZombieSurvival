using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBarUpdater : MonoBehaviour
{
    public Image healthBar;
    public Image staminaBar;
    public Image hungerBar;
    public Image thirstBar;
    public GameObject player;

    private PlayerStats statScript;
    private float currentHealth;
    private float currentStamina;
    private float currentHunger;
    private float currentThirst;
    private float maxHealth = 100f;
    private float maxStamina = 100f;
    private float maxHunger = 100f;
    private float maxThirst = 100f;

    public void Start()
    {
        statScript = player.GetComponent<PlayerStats>();
    }

    public void Update()
    {
        currentHealth = statScript.health;
        healthBar.fillAmount = currentHealth / maxHealth;

        currentStamina = statScript.stamina;
        staminaBar.fillAmount = currentStamina / maxStamina;

        currentHunger = statScript.hunger;
        hungerBar.fillAmount = currentHunger / maxHunger;

        currentThirst = statScript.thirst;
        thirstBar.fillAmount = currentThirst / maxThirst;
    }
}
