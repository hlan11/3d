using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PanelGameOver;
    public void OnGameover()
    {
        Time.timeScale = 0;
        PanelGameOver.SetActive(true);
    }
    public void ReplayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("5.5");
    }
}
