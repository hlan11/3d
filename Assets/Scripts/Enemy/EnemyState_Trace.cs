using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMHelper;

public class EnemyState_Trace : BaseFSMState
{
    private EnemyStateMachine _enemySM;
    private Transform _target;
    public override void Enter()
    {
        Debug.Log("-----------------Enter State Trace-------------------");
        if (_enemySM == null)
        {
            _enemySM = (EnemyStateMachine)GetStateMachine();
        }
    }
    public override void Update()
    {
        _enemySM.EnemyAI.Agent.SetDestination(Player.Instance.PlayerFoot.transform.position);
        if(Vector3.Distance(_enemySM.EnemyAI.transform.position, _enemySM.EnemyAI.spawnPos.position) > 30f)
        {
            DoTransition(typeof(EnemyState_Retreat));
        }
        else if (Vector3.Distance(_enemySM.EnemyAI.transform.position, Player.Instance.PlayerFoot.transform.position) < 2f)
        {
            DoTransition(typeof(EnemyState_Attack));
        }
    }
    public override void ReceiveMessage(object[] args)
    {
        if (args.Length == 1 && (string)args[0] == "Attack")
        {
            DoTransition(typeof(EnemyState_Attack));
        }
        else if (args.Length == 1 && (string)args[0] == "Retreat")
        {
            DoTransition(typeof(EnemyState_Retreat));
        }
    }
}
