using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private EnemySO EnemySO;

    private Health playerHealth;
    bool isAttack;

    private EnemyStateMachine _enemySM;
    private Player _player;

    [Header("Spherecast")]
    [SerializeField] private float sphereRadius;
    [SerializeField] private float maxDistance;
    private Vector3 origin;
    private Vector3 direction;
    public LayerMask enemyLayer;
    public GameObject currentHitObject;
    private float currentHitDistance;

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
    public void DetectEnemyPlayer()
    {
        Debug.Log("--------------------Enemy attack player----------------------");
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, enemyLayer, QueryTriggerInteraction.UseGlobal))
        {
            Debug.Log("Attack player==============");
            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            playerHealth.TakeDamage(10);
        }
        else
        {
            currentHitDistance = maxDistance;
            currentHitObject = null;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }
}
