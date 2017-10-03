using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Linq;
[RequireComponent(typeof(Inventory))]
public class InventoryUI : MonoBehaviour{

    static Inventory inv;
    List<SlotUI> slotsScript = new List<SlotUI>();
    public List<Image> slotsIcon = new List<Image>();
    public Color slotHoverColor;

    private void Start()
    {
        inv = Inventory.Instance;
        inv.InventoryRefresh += RefreshInventoryUi;

        slotsInit();
        
    }

    void slotsInit()
    {

        GameObject[] slotsObjects = inv.getSlots();
        
        for(int i = 0; i < slotsObjects.Length; i++)
        {
            slotsScript.Add(slotsObjects[i].GetComponent<SlotUI>());
            slotsIcon.Add(slotsObjects[i].GetComponentsInChildren<Image>()[1]);
        }

        if (slotsScript.Count != 0)
        {
            for (int i = 0; i < slotsScript.Count; i++)
            {
                slotsScript[i].index = i;
                slotsScript[i].hover += hover;
                slotsScript[i].hoverColor = slotHoverColor;
            }
        }
    }

    void RefreshInventoryUi()
    {

        
        Item[] items = inv.getItems();
        int numItemSlots = inv.getNumItemSlots();

        for (int i = 0; i < numItemSlots; i++)
        {

            if (items[i] != null)
            {
                slotsIcon[i].sprite = items[i].itemIcon;
                slotsIcon[i].enabled = true;
            }
            else
            {
                slotsIcon[i].enabled = false;
            }

        }
        
    }

    void hover(int i)
    {
        Debug.Log(i);
    }

}
