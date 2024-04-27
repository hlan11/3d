using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName ="Item",menuName="Create New Pickup Items")]
[System.Serializable]
public class ItemData : ScriptableObject
{
    public string itemName;
    public int Health;
    public int Mana;
    public int coins;
    public int Armor;
    public Sprite icon;
}
