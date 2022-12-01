using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IuFuntions
{
    private Fsm _Fsm;
    private Waypoints Hunter;
    List<Node> FollowWay = new List<Node>();
    PathFinding _Pathf = new PathFinding();
    public Node startingNode;
    public Node goalNode;
    public PatrolState(Fsm _FSM, Waypoints _Hunter, List<Node> _FollowWay, PathFinding _Pathfinding, Node Start, Node GoalNode)
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
        Hunter.MyForce(Patrol());
        if(Hunter.Fov(Hunter.playerPrefab.transform.position))
        {
            _Fsm.ChangeState(States.Chase);
        }
    }
    public Vector3 Patrol()
    {
        GameObject waypoint = Hunter.allWaypoints[Hunter._currentWay];
        Vector3 dir = waypoint.transform.position - Hunter.transform.position;
        dir.y = 0;
        Hunter.transform.forward = dir;
        Hunter.transform.position += Hunter.transform.forward * Hunter._movementSpeed * Time.deltaTime;

        if(dir.magnitude <= 0.3f)
        {
            Hunter._currentWay++;
            if (Hunter._currentWay > Hunter.allWaypoints.Length - 1)
            {
                Hunter._currentWay = 0;
            }
        }
        return Hunter.SteeringCalculate(dir);
    }

    public void OnExit()
    {
        
    }

}
