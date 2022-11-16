using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPatrolState : IStates
{
    FiniteStateMachine _fsm;

    public BPatrolState(FiniteStateMachine fsm)
    {
        _fsm = fsm;
    }

    public void OnEnter()
    {
        Debug.Log("Enemigo entra a Patrol");
    }

    public void OnUpdate()
    {
        Debug.Log("Enemigo en Patrol");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _fsm.ChangeState(MyEnum.Chase);
        }
    }

    public void OnExit()
    {
        Debug.Log("Enemigo sale de Patrol");
    }
}
