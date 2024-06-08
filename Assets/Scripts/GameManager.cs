using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PanelGameOver;
    public void OnGameover()
    {
        Time.timeScale = 0;
        PanelGameOver.SetActive(true);
    }
    
}