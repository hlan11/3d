using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject panelPauseGame;
    private bool isPause;
    [SerializeField] private GameObject inventory;
    public void resumeButton()
    {
        Time.timeScale = 1;
        panelPauseGame.SetActive(false);
        isPause = false;
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
        panelPauseGame.SetActive(true);
        isPause=true;
    }
    public void exitGame()
    {
        SceneManager.LoadScene(0);
    }
    public void openInventory()
    {
        inventory.SetActive(true);
        Time.timeScale = 0;
    }
    public void closeInventory()
    {
        inventory.SetActive(false);
        Time.timeScale = 1;
    }
}
