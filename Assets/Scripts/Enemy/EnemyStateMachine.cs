using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMHelper;
using System;

public class EnemyStateMachine : FSMStateMachine
{
    public EnemyAI EnemyAI = null;
    public EnemyStateMachine(EnemyAI ai)
    {
        EnemyAI = ai;
    }
    public override void SetupDefinition(ref FSMStateType stateType, ref List<System.Type> children)
    {
        children.Add(typeof(EnemyState_Patrol));
        children.Add(typeof(EnemyState_Attack));
        children.Add(typeof(EnemyState_Retreat));
    }
}
