using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float stamina;
    public float hunger;
    public float thirst;

    public float hungerGainer;
    public float thirstGainer;

    private float hungerTimer;
    private float thirstTimer;

    private float hungerHealthImpactTimer;
    private float thirstHealthImpactTimer;

    private float hungerHealthImpactTime = 20f;
    private float thristHealthImpactTime = 10f;

    private WaitForSeconds regenTick = new WaitForSeconds(0.2f);
    private Coroutine regen;

    public void Update()
    {
        UpdateHealth();
        UpdateStamina();
        UpdateThirst();
        UpdateHunger();
    }

    //healthbar
    public void UpdateHealth()
    {
        if (health > 100f)
        {
            health = 100f;
        }
        else if (health <= 0f)
        {
            health = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene(2);
        }
    }

    //stamina bar
    public void UpdateStamina()
    {
        if (stamina > 100f)
        {
            stamina = 100f;
        }
        else if(stamina < 0f)
        {
            stamina = 0f;
        }

        if((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            UseStamina(0.1f);
        }
        else
        {
            FindObjectOfType<PlayerMovement>().speed = 4f;
        }
    }

    public void UseStamina(float amount)
    {
        if((stamina - amount) > 0f)
        {
            stamina -= amount;
            FindObjectOfType<PlayerMovement>().speed = 7f;

            if(regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            FindObjectOfType<PlayerMovement>().speed = 4f;
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(1);

        while(stamina < 100f)
        {
            stamina += 0.75f;
            yield return regenTick;
        }
    }



    ///hunger bar
    public void UpdateHunger()
    {
        hungerHealthImpactTimer += Time.deltaTime;
        
        if (hunger > 100f)
        {
            hunger = 100f;
        }
        else if (hunger <= 0f)
        {
            hunger = 0f;
            if ((hungerHealthImpactTimer >= hungerHealthImpactTime) && (health > 10f))
            {
                health -= 10f;
                hungerHealthImpactTimer = 0f;
            }
        }

        hungerTimer += Time.deltaTime;

        if (hungerTimer >= hungerGainer)
        {
            hunger -= 5f;
            hungerTimer = 0f;
        }
    }


    //thirst bar
    public void UpdateThirst()
    {
        thirstHealthImpactTimer += Time.deltaTime;

        if (thirst > 100f)
        {
            thirst = 100f;
        }
        else if (thirst <= 0f)
        {
            thirst = 0f;
            if ((thirstHealthImpactTimer >= thristHealthImpactTime) && (health > 10f))
            {
                health -= 10f;
                thirstHealthImpactTimer = 0f;
            }
        }

        thirstTimer += Time.deltaTime;

        if (thirstTimer >= thirstGainer)
        {
            thirst -= 5f;
            thirstTimer = 0f;
        }
    }
}
