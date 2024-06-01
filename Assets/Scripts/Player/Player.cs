using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] private Transform playerFoot;
    [SerializeField] private HealthBar playerHealth;
    public Transform PlayerFoot=> playerFoot;
    public HealthBar PlayerHealth => playerHealth;
}
