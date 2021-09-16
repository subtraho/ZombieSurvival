using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float stamina;
    public float hunger;
    public float thirst;

    public void Update()
    {
        if(health > 100f)
        {
            health = 100f;
        }

        if (stamina > 100f)
        {
            stamina = 100f;
        }

        if (hunger > 100f)
        {
            hunger = 100f;
        }

        if (thirst > 100f)
        {
            thirst = 100f;
        }
    }
}
