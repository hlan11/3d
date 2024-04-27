using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health :  MonoBehaviour
{
    [SerializeField] private Slider maxHealth;
    [SerializeField] private float currentHealth = 100;
    //public InventoryButton inventoryButton;
    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log("currentHealth - 10");
            currentHealth -= 10;
        }
    }
    void UpdateSlider()
    {
        currentHealth = maxHealth.value;
    }
    private void Update()
    {
        UpdateSlider();
    }
}
