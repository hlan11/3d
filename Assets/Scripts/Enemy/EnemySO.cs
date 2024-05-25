using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="EnemySO",menuName ="Create new Enemy")]
[System.Serializable]
public class EnemySO : ScriptableObject
{
    public int HP;
    public int damage;
    public float speed;
}
