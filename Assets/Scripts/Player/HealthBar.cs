using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private Slider easeHealthSlider;
    [SerializeField]private float lerpSpeed;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (healthBar.value != currentHealth)
        {
            healthBar.value = currentHealth;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            takeDamage(10);
        }
        if(healthBar.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, currentHealth, lerpSpeed);
        }
    }
    void takeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
