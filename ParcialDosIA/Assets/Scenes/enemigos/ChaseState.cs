using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IuFuncionStates
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
        Agent AgentsKilled = null;
        foreach (var Bots in GameManager.Instance.FriendBots)
        {
            Vector3 DistAllBots = Bots.transform.position - Hunter.transform.position;
            Hunter.CurrentStamine -= 1f * Time.deltaTime;
            if (DistAllBots.magnitude <= Hunter.VisionRadius)
            {
                Vector3 ProxPos = Bots.transform.position + Bots.GetMySpeed() * Time.deltaTime;
                Desired = ProxPos - Hunter.transform.position;
            }
        }
        if (Desired == Vector3.zero && Hunter.CurrentStamine >= 1 && Hunter.FullStamine==true)
        {
            Fsm.ChangeState(States.Patrol);
        }
        return Hunter.SteeringCalculate(Desired);
    }
    public void OnExit()
    {

    }
}
