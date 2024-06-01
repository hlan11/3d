using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private EnemySO EnemySO;

    private HealthBar playerHealth;
    private void Start()
    {
        
    }
    public void StartAttack()
    {
        anim.SetBool("isAttacking", true);
    }
    public void StopAttack()
    {
        anim.SetBool("isAttacking", false);
    }
}
