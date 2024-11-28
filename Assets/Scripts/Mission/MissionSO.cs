using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Create Mission")]
public class MissionSO : ScriptableObject
{
    public List<MissionInfor> listMission = new List<MissionInfor>();
}
[System.Serializable]
public class MissionInfor
{
    public int PotionCollected;
}
