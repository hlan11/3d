using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMHelper;
using UnityEngine.AI;
using Unity.VisualScripting;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private EnemyAttack enemyAttack;
    public Animator Animator => animator;
    public NavMeshAgent Agent => agent;
    public EnemyAttack EnemyAttack => enemyAttack;
    private EnemyStateMachine m_enemySM = null;
    private void Start()
    {
        m_enemySM=new EnemyStateMachine(this);
        m_enemySM.StartSM();
    }
    private void Update()
    {
        m_enemySM.UpdateSM();
    }
    private void OnDestroy()
    {
        if(m_enemySM!=null)
        {
            m_enemySM.StopSM();
            m_enemySM = null;
        }
    }
    public void Patrol()
    {
        object[] args = new object[1];
        args[0] = "Patrol";
        m_enemySM.BroadcastMessage(args);
    }
    public void TracePlayer()
    {
        object[] args = new object[1];
        args[0] = "Trace";
        m_enemySM.BroadcastMessage(args);
    }
    public void AttackPlayer()
    {
        object[]args=new object[1];
        args[0] = "Attack";
        m_enemySM.BroadcastMessage(args);
    }
}
