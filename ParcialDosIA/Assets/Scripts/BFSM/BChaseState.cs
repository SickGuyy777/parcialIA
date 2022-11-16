using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BChaseState : IStates
{
    FiniteStateMachine _fsm;

    public BChaseState(FiniteStateMachine fsm)
    {
        _fsm = fsm;
    }

    public void OnEnter()
    {

    }

    public void OnUpdate()
    {
        Debug.Log("El enemigo esta patrullando");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _fsm.ChangeState(MyEnum.Patrol);
        }
    }

    public void OnExit()
    {

    }
}
