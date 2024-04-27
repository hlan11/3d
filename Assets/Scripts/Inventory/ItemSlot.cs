using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemAmountText;
    //public ItemData itemdata;
    public InventoryItem item;
    public void UpdateSlot(InventoryItem _newItem)
    {
        item = _newItem;
        if (item != null)
        {
            itemImage.sprite = item.data.icon;
            //itemImage.sprite = itemdata.icon;
            if (item.stackSize > 1)
            {
                itemAmountText.text = item.stackSize.ToString();
            }
            else
            {
                itemAmountText.text = "";
            }
        }
    }
}
