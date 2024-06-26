using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class MissionManager : Singleton<MissionManager>
{
    [SerializeField] private MissionSO missionSO;
    [SerializeField] private TextMeshProUGUI textMission;
    [SerializeField] private Gate exitDoor;
    private int requiredPotion;
    private int currentPotionCollected;
    private bool isPlayerExit;
    private IEnumerator VerifyPotionCollected()
    {
        currentPotionCollected = 0;
        textMission.text = $"Your mission : Collect {requiredPotion} Red Potion " + $"------ Collected {currentPotionCollected} Red Potion";
        yield return new WaitUntil(()=>isMissionCompleted());
    }
    private void Start()
    {
        InitMisson();
        StartCoroutine(VerifyMission());
    }
    private IEnumerator VerifyMission()
    {
        yield return VerifyPotionCollected();
        yield return VerifyPlayerExit();
        GameManager.Instance.OnMissionCompleted();
    }
    private IEnumerator VerifyPlayerExit()
    {
        textMission.text = $"Mission Completed , find exit door";
        exitDoor.onPlayerEnter.AddListener(OnPlayerExit);
        yield return new WaitUntil(() => isPlayerExit);
        exitDoor.onPlayerEnter.RemoveListener(OnPlayerExit);
    }
    public void CollectPotion()
    {
        currentPotionCollected++;
        textMission.text = $"Your mission : Collect {requiredPotion} Potion " + $"------ Collected {currentPotionCollected} Potion";
        //Debug.Log("---------------------Potion Collected-----------------------");
    }
    private void InitMisson()
    {
        var index = GameManager.Instance.currentLevel - 1;
        var collectPotionMission = missionSO.listMission[index].PotionCollected;
        requiredPotion = collectPotionMission;
    }
    private bool isMissionCompleted()
    {
        return requiredPotion == currentPotionCollected;
    }
    private void OnPlayerExit()
    {
        isPlayerExit = true;
    }
}
