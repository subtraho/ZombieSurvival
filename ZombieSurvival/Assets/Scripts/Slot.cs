using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject inventory;
    public Sprite backgroundIcon;
    public GameObject item;
    public int slotNumber;
    public int ID;
    public string type;
    public string description;
    public bool empty;
    public Sprite icon;
    public Transform slotIconGO;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if(item != null)
        {
            UseItem();
        }
    }

    private void Start()
    {
        slotIconGO = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        if(icon != null)
        {
            slotIconGO.GetComponent<Image>().sprite = icon;
            slotIconGO.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            slotIconGO.GetComponent<Image>().sprite = backgroundIcon;
            slotIconGO.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        }
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();

        if(type == "Healh" || type == "Food" || type == "Drink")
        {
            Destroy(item);
            inventory.GetComponent<Inventory>().RemoveItem(slotNumber);
        }
    }
}
