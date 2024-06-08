using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMHelper;
using UnityEngine.AI;
using Palmmedia.ReportGenerator.Core;

public class EnemyState_Idle : BaseFSMState
{
    private EnemyStateMachine _enemySM;

    private Transform _patrolCenter;
    public float patrolRadius = 10f;
    public float minDistanceToTarget = 2f;
    public float stoppingDistance = 1f;
    public float speed = 3f;
    private NavMeshAgent _agent;
    public override void Enter()
    {
        Debug.Log("-------------------Enter State Idle --------------------");
        if (_enemySM == null)
        {
            _enemySM = (EnemyStateMachine)GetStateMachine();
        }
        _patrolCenter = _enemySM.EnemyAI.spawnPos;
        _agent = _enemySM.EnemyAI.Agent;
        _agent.speed = speed;
        _agent.stoppingDistance = stoppingDistance;
        SetNewDestination();
        _enemySM.EnemyAI.Animator.SetBool("isWalking", true);
    }
    public override void Update()
    {
        if (!_enemySM.EnemyAI.Agent.pathPending && _enemySM.EnemyAI.Agent.remainingDistance <= _enemySM.EnemyAI.Agent.stoppingDistance)
        {
            SetNewDestination();
        }
    }
    void SetNewDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        Vector3 newDirection=_patrolCenter.position + randomDirection;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(newDirection, out hit , patrolRadius , NavMesh.AllAreas))
        {
            _enemySM.EnemyAI.Agent.SetDestination(hit.position);
        }
    }
    public override void ReceiveMessage(object[] args)
    {
         Debug.Log("============ State Idle receved message : " + args.ToString());
        if (args.Length == 1 && (string)args[0] == "Trace")
        {
            Debug.Log("====== switch trace player");
            DoTransition(typeof(EnemyState_Trace));
        }
    }
}
