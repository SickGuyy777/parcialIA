using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MyEnum
{
    Patrol,
    Chase
}

public class EnemyController : MonoBehaviour
{
    FiniteStateMachine _FSM;

    private void Start()
    {
        _FSM = new FiniteStateMachine();
        var patrol = new BPatrolState(_FSM);
        _FSM.AddState(MyEnum.Patrol, patrol);
        _FSM.AddState(MyEnum.Chase, new BChaseState(_FSM));
        _FSM.ChangeState(MyEnum.Patrol);
    }

    private void Update()
    {
        _FSM.Update();
    }
}
