using System.Collections;
using System.Collections.Generic;
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
        base.Die();
    }
}
