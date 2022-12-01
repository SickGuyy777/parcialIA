using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState :IuFuntions
{
    private Fsm _Fsm;
    private Waypoints enemyAgent;
    List<Node> FollowWay = new List<Node>();
    PathFinding _Pathf = new PathFinding();
    public Node startingNode;
    public Node goalNode;

    public ChaseState(Fsm _FSM, Waypoints _Hunter, List<Node> _FollowWay,PathFinding _Pathfinding,Node Start,Node GoalNode)
    {
        _Fsm = _FSM;
        enemyAgent = _Hunter;
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
        //enemyAgent.MyForce(Chase());
        //if (!enemyAgent.Fov(enemyAgent.playerPrefab.transform.position))
        //{
        //    _Fsm.ChangeState(States.Patrol);
        //}

        Chase();
        if (!enemyAgent.Fov(enemyAgent.playerPrefab.transform.position))
        {
            _Fsm.ChangeState(States.Patrol);
        }
    }
    public Vector3 Chase()
    {
        Vector3 desired = Vector3.zero;
        foreach (var player in GameManager.Instance.Player)
        {
            Vector3 dir = enemyAgent.transform.position - player.transform.position;
            if (dir.magnitude <= enemyAgent.viewAngle)
            {
                enemyAgent.transform.forward = dir;
                enemyAgent.transform.position -= dir.normalized * enemyAgent._movementSpeed * Time.deltaTime;
                desired = dir;
            }
        }

        //Vector3 Desired = Vector3.zero;
        //foreach (var Bots in GameManager.Instance.Player)
        //{
        //    Vector3 DistAllBots = Bots.transform.position - Hunter.transform.position;
        //    if (DistAllBots.magnitude <= Hunter.viewAngle)
        //    {
        //        Bots.transform.position += DistAllBots * Hunter._movementSpeed * Time.deltaTime;
        //        Bots.transform.forward = DistAllBots;
        //       //Vector3 ProxPos = Bots.transform.position + Bots.GetMySpeed() * Time.deltaTime;
        //       //Desired = ProxPos - Hunter.transform.position;
        //    }
        //}
        enemyAgent.Notify = true;
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
        return enemyAgent.SteeringCalculate(desired);

    }

    public void OnExit()
    {

    }
}
