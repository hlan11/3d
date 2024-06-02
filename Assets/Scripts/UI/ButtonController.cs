using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject panelPauseGame;
    private bool isPause = false;
    // [SerializeField] private GameObject inventory;
     private HealthBar _playerHealth;
     [SerializeField] private ItemData _itemData;
    private ItemData _itemdata;
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
    public void UsePotion()
    {
        if (_itemData != null)
        {
            if (_itemdata.itemName == "HealthPotion")
            {
                Debug.Log("-------Use Health Potion + Health ------------------");
                _playerHealth.currentHealth += _itemdata.Health;
            }
            if (_itemdata.itemName == "ArmorPotion" )
            {
                    Debug.Log("----------------Use Armor Potion-----------------");
            }
            if (_itemdata.itemName == "Coin")
            {
                    Debug.Log("-------------Picked Up Coins---------------");
            }
            if (_itemdata.itemName == "ManaPotion")
            {
                    Debug.Log("-------------Picked Up ManaPotion---------------");
            }
        }
        else
        {
            Debug.Log("==================Object null===========================");
            return;
        }
    }
    public void exitGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("5.5");
    }
    
}
