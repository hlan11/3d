using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private EnemySO _enemySO;
    protected override void Start()
    {
        base.Start();
        MaxHP=_enemySO.HP;
    }
    protected override void Die()
    {
        if(MaxHP<=0)
        base.Die();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            Debug.Log("Enemy under attack");
            MaxHP -= 20;
        }
    }
}
