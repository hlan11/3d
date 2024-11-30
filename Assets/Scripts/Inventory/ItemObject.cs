using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    
    private void Start()
    {
        //GetComponent<SpriteRenderer>().sprite = itemData.icon;
        gameObject.name= itemData.name;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.instance.addItem(itemData);
            //Debug.Log("Pick Up item " + itemData.name + " Health = " + itemData.Health+ " Mana = " + itemData.Mana+ " Armor = " + itemData.Armor+ " Coin = " + itemData.coins);
            Destroy(gameObject);
            if (itemData.name == "HealthPotion")
            {
                MissionManager.Instance.CollectPotion();
                
          
            }
        }
    }
   
}
