using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDrinkHealthItem : MonoBehaviour
{
    public PlayerStats statScript;
    public float statbarPoints;

    private Item itemScript;
    
    public void UseItem()
    {
        if(gameObject.GetComponent<Item>().type == "Food")
        {
            statScript.hunger += statbarPoints;
        }
        else if(gameObject.GetComponent<Item>().type == "Drink")
        {
            statScript.thirst += statbarPoints;
        }
        else if(gameObject.GetComponent<Item>().type == "Health")
        {
            statScript.health += statbarPoints;
        }
    }
}
