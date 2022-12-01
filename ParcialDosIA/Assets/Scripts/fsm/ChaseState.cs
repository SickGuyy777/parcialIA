using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState :IuFuntions
{
    private Fsm _Fsm;
    private Waypoints Hunter;
    List<Node> FollowWay = new List<Node>();
    PathFinding _Pathf = new PathFinding();
    public Node startingNode;
    public Node goalNode;

    public ChaseState(Fsm _FSM, Waypoints _Hunter, List<Node> _FollowWay,PathFinding _Pathfinding,Node Start,Node GoalNode)
    {
        _Fsm = _FSM;
        Hunter = _Hunter;
        FollowWay = _FollowWay;
        _Pathf = _Pathfinding;
        startingNode = Start;
        goalNode = GoalNode;
    }
    public void OnEnter()
    {
        
    }

    public void OnUpdate()
    {
        Hunter.MyForce(Chase());
        if (!Hunter.Fov(Hunter.playerPrefab.transform.position))
        {
            _Fsm.ChangeState(States.Patrol);
        }
    }
    public Vector3 Chase()
    {
        Vector3 Desired = Vector3.zero;
        foreach (var Bots in GameManager.Instance.Player)
        {
            Vector3 DistAllBots = Bots.transform.position - Hunter.transform.position;
            if (DistAllBots.magnitude <= Hunter.viewRadius)
            {
              Vector3 ProxPos = Bots.transform.position + Bots.GetMySpeed() * Time.deltaTime;
              Desired = ProxPos - Hunter.transform.position;
            }
        }
        Hunter.Notify = true;
        //este if que esta abajo lo tenemos que ver
        //if (Hunter.Notify == true)
        //{
        //    foreach (Waypoints Hunters in GameManager.Instance.Hunters)
        //    {
        //            FollowWay = _Pathf.AStar(startingNode, goalNode);
        //            if (FollowWay.Count != 0)
        //            {
        //                Hunter.FollowPath();
        //            }    
        //    }
        //}
        return Hunter.SteeringCalculate(Desired);

    }

    public void OnExit()
    {

    }
}
