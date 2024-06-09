using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private EnemySO EnemySO;

    private Health playerHealth;
    bool isAttack;

    private EnemyStateMachine _enemySM;
    private Player _player;
    private void Start()
    {
        playerHealth = Player.Instance.PlayerHealth;
    }
    public void StartAttack()
    {
        anim.SetBool("isAttacking", true);
        anim.SetBool("isWalking", false);
        if (!isAttack)
        {
            isAttack = true;
            InvokeRepeating("OnAttack", 0.1f, 2f);
        }
    }
    public void StopAttack()
    {
        anim.SetBool("isAttacking", false);
        anim.SetBool("isWalking", true);
        //isAttack = false;
        if (Vector3.Distance(_enemySM.EnemyAI.transform.position, _player.PlayerFoot.transform.position) > 1.0f && isAttack)
        {
            Debug.Log("------------isAttack == false=============");
            isAttack = false;
        }
    }
    public void OnAttack()
    {
        if (playerHealth != null && isAttack)
        {
            playerHealth.TakeDamage(EnemySO.Damage);
        }
    }
}
