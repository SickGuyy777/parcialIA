using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IuFuncionStates
{
    private FSM FiniteStateMachine;
    private EnemyManager Hunter;
    public PatrolState(FSM _Fsm, Hunter _Hunter)
    {
        FiniteStateMachine = _Fsm;
        Hunter = _Hunter;
    }
    public void OnEnter()
    {

    }

    public void OnUpdate()//aca programamos las acciones que queremos hacer mientras esta en este estado y en el caso que tengamos mas estados cambiarlos
    {
        EnemyManager.MyForce(Patrol());
        if (Hunter.DetectPresa == true)
        {
            FiniteStateMachine.ChangeState(States.Chase);
        }
    }
    public Vector3 Patrol()
    {
        GameObject WayPoint = Hunter.AllPatrollPoints[Hunter.ActualPatrolPoint];
        Vector3 Dir = WayPoint.transform.position - Hunter.transform.position;
        Dir.y = 0;
        Hunter.transform.forward = Dir;
        Hunter.transform.position += Hunter.transform.forward * Hunter.MaxSpeed * Time.deltaTime;
        if (Dir.magnitude <= 0.3f)
        {
            Hunter.ActualPatrolPoint++;
            if (Hunter.ActualPatrolPoint > Hunter.AllPatrollPoints.Length - 1)
            {
                Hunter.ActualPatrolPoint = 0;
            }
        }
        return Hunter.SteeringCalculate(Dir);
    }

    public void OnExit()
    {

    }
}
