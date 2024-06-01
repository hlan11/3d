using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMHelper;

public class EnemyState_Attack : BaseFSMState
{
    private EnemyStateMachine _enemySM;
    public override void Enter()
    {
        Debug.Log("============ Enemy Attaack===========");
        if (_enemySM == null)
        {
            _enemySM = (EnemyStateMachine)GetStateMachine();
        }
        _enemySM.EnemyAI.EnemyAttack.StartAttack();
    }
    public override void Update()
    {
        _enemySM.EnemyAI.Agent.SetDestination(Player.Instance.PlayerFoot.transform.position);

        if (Vector3.Distance(_enemySM.EnemyAI.transform.position, _enemySM.EnemyAI.spawnPos.position) > 30f)
        {
            DoTransition(typeof(EnemyState_Retreat));
        }
    }
    public override void Exit()
    {
        _enemySM.EnemyAI.EnemyAttack.StopAttack();
    }
    public override void ReceiveMessage(object[] args)
    {
        if (args.Length == 1 && (string)args[0] == "Retreat")
        {
            DoTransition(typeof(EnemyState_Retreat));
        }
    }
}
