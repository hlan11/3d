using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<InventoryItem> inventoryItems;
    public Dictionary<ItemData, InventoryItem> inventoryDictionary;
    [Header("Inventory UI")]
    [SerializeField] private Transform inventorySlotParent;
    private ItemSlot[] itemsSlot;
    private void Start()
    {
        inventoryItems = new List<InventoryItem>();
        inventoryDictionary= new Dictionary<ItemData, InventoryItem>();
        itemsSlot=inventorySlotParent.GetComponentsInChildren<ItemSlot>();
    }
    void UpdateSlotUI()
    {
        for(int i=0;i< inventoryItems.Count; i++)
        {
            itemsSlot[i].UpdateSlot(inventoryItems[i]);
        }
    }
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void addItem(ItemData _item)
    {
        if(inventoryDictionary.TryGetValue(_item,out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(_item);
            inventoryItems.Add(newItem);
            inventoryDictionary.Add(_item, newItem);
        }
        UpdateSlotUI();
    }
    public void RemoveStack(ItemData _item)
    {
        if(inventoryDictionary.TryGetValue(_item,out InventoryItem value))
        {
            if (value.stackSize <= 1)
            {
                inventoryItems.Remove(value);
                inventoryDictionary.Remove(_item);
            }
        }
        else
        {
            value.RemoveStack();
        }
        UpdateSlotUI();
    }
}
