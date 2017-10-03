using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public delegate void InventoryChanged();
    public event InventoryChanged InventoryRefresh;


    [SerializeField]
    private GameObject[] Slots = new GameObject[numItemSlots];
    [SerializeField]
    private Item[] items = new Item[numItemSlots];

    public const int numItemSlots = 5;

    #region Singleton
    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    
    #endregion
  
    #region Get Set


    public int getNumItemSlots()
    {
        return numItemSlots;
    }

    public GameObject[] getSlots()
    {
        return Slots;
    }

    public Item[] getItems()
    {
        return items;
    }
    #endregion

    void Update() {

        if (InventoryRefresh != null)
            InventoryRefresh();
    }

    public void slotHover(int slot)
    {

        Debug.Log("Mouse hovers over slot:" + slot);
    }
  
}
