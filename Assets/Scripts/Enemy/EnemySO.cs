using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="EnemySO",menuName ="Create new Enemy")]
[System.Serializable]
public class EnemySO : ScriptableObject
{
    public int HP;
    public int Damage;
    public float speed;
}
