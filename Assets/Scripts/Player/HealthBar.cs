using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float maxHealth=100;
    public float currentHealth { get; set; }
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject panelLoseGame;
    private void Start()
    {
        anim=GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    private void Update()
    {
        healthSlider.value = currentHealth;
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("------------Press B----------------");
            currentHealth -= 10;
        }
        CheckDie();
        
    }
    void CheckDie()
    {
        if (currentHealth <= 0)
        {
            anim.SetTrigger("Die");
            panelLoseGame.SetActive(true);
        }
    }
}
