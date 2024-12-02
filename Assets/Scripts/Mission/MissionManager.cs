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
    private void Start()
    {
        InitMisson();
        StartCoroutine(VerifyMission());
    }
    IEnumerator VerifyMission()
    {
        yield return VerifyPotionCollected();
        yield return VerifyPlayerExit();
    }
    private IEnumerator VerifyPotionCollected()
    {
        currentPotionCollected = 0;
        textMission.text = $"Collect {requiredPotion} Red Potion " + $"------ Collected {currentPotionCollected} potion";
        yield return new WaitUntil(() => isMissionCompleted());
    }
    private IEnumerator VerifyPlayerExit()
    {
        textMission.text = $"Mission Completed , go to treasure ";
        exitDoor.onPlayerEnter.AddListener(OnPlayerExit);
        yield return new WaitUntil(() => isPlayerExit);
        exitDoor.onPlayerEnter.RemoveListener(OnPlayerExit);
    }
    public void CollectPotion()
    {
        currentPotionCollected++;
        textMission.text = $"Collect {requiredPotion} Red Potion " + $"------ Collected {currentPotionCollected} potion";

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