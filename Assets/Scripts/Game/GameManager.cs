using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject PanelGameOver;
    [SerializeField]private GameObject PanelGameWin;
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
    public void OnMissionCompleted()
    {
        Time.timeScale = 0;
        PanelGameWin.SetActive(true);
    }
}
