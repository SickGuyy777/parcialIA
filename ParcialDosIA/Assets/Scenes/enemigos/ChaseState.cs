using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IuFuncionsStates
{
    private FSM Fsm;
    private EnemyManager Hunter;
    
    public ChaseState(FSM _Fsm, EnemyManager _Hunter)
    {
        Fsm = _Fsm;
        Hunter = _Hunter;
    }
    public void OnEnter()
    {

    }

    public void OnUpdate()
    {
        Hunter.MyForce(Chase());
    }
    public Vector3 Chase()
    {
        Vector3 Desired = Vector3.zero;
        PlayerMovement AgentsKilled = null;
        foreach (var Bots in GameManager.Instance.Player)
        {
            Vector3 DistAllBots = Bots.transform.position - Hunter.transform.position;
            if (DistAllBots.magnitude <= Hunter.VisionRadius)
            {
                Vector3 ProxPos = Bots.transform.position + Bots.GetMySpeed() * Time.deltaTime;
                Desired = ProxPos - Hunter.transform.position;
            }
        }
        if (Desired == Vector3.zero)
        {
            Fsm.ChangeState(States.Patrol);
        }
        return Hunter.SteeringCalculate(Desired);
    }
    public void OnExit()
    {

    }
}
