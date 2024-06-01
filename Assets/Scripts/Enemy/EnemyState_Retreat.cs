using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMHelper;

public class EnemyState_Retreat : BaseFSMState
{
    private EnemyStateMachine _enemySM;
    public override void Enter()
    {
        if (_enemySM == null)
        {
            _enemySM = (EnemyStateMachine)GetStateMachine();
        }
    }
    public override void Update()
    {
        _enemySM.EnemyAI.Agent.SetDestination(_enemySM.EnemyAI.spawnPos.position);
        if (Vector3.Distance(_enemySM.EnemyAI.transform.position, _enemySM.EnemyAI.spawnPos.position) <= 1f)
        {
            DoTransition(typeof(EnemyState_Idle));
        }
    }
    public override void ReceiveMessage(object[] args)
    {
        if (args.Length == 1 && (string)args[0] == "Patrol")
        {
            DoTransition(typeof(EnemyState_Idle));
        }
    }
}
