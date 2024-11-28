using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject PanelGameOver;
    [SerializeField] private GameObject PanelGameWin;
    [SerializeField] private GameObject instructionPanel;
    public int currentLevel;
    private void Start()
    {
        currentLevel = 1;
        //instructionPanel.SetActive(false);
    }
    public void showInstruction()
    {
        //instructionPanel.SetActive(true);
        Debug.Log("Panel has been showed");
    }
    public void hideInstruction()
    {
        instructionPanel.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("5.5");
    }
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
