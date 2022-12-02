using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum States
{
    Idle,
    Patrol,
    Chase,
}
public class Waypoints : MonoBehaviour
{
    public GameObject[] allWaypoints;
    public Transform playerPrefab;
    public PlayerMovement pl;
    public Node startingNode;
    public Node goalNode;
    List<Node> FollowWay = new List<Node>();
    PathFinding _Pathf = new PathFinding();
    public Fsm StateMachine;
    public float MaxSpeed;
    public float viewRadius;
    public float viewAngle;
    public int _currentWay = 0;
    public float _movementSpeed;
    public bool Notify = false;
    public float MaxForceRot;
    public LayerMask wallLayer;
    public LayerMask SeeNodes;
    public Vector3 Player;
    private Vector3 _MySpeed;

    private void Start()
    {
        GameManager.Instance.AddHuntter(this);
        StateMachine = new Fsm();
        var Patrol = new PatrolState(StateMachine, this,FollowWay,_Pathf,startingNode,goalNode);
        var ChaseState = new ChaseState(StateMachine, this, FollowWay, _Pathf, startingNode, goalNode);
        StateMachine.AddStatesInDiccionary(States.Patrol, Patrol);
        StateMachine.AddStatesInDiccionary(States.Chase, ChaseState);
        StateMachine.ChangeState(States.Patrol);//le decimos cual es su estado principal para que inicie
    }
    private void Update()
    {
        StateMachine.ArtificialUpdate();//para que cambie su estado constantemente
        transform.position += _MySpeed * Time.deltaTime;
        transform.forward = _MySpeed;
    }

    public Vector3 GetMySpeed()//para que pueda obtener my vector que transforma mi posicion
    {
        return _MySpeed;
    }
            //esto tiene que hacerce una vez a lo mejor con una corrutina en patrol y creo que chase
            //FollowWay = _Pathf.AStar(startingNode, goalNode);
            //if (FollowWay.Count != 0)
            //{
            //    FollowPath();
            //}

    public Vector3 SteeringCalculate(Vector3 desired)
    {
        return Vector3.ClampMagnitude((desired.normalized * MaxSpeed) - _MySpeed, MaxForceRot);
    }

    public void MyForce(Vector3 force)
    {
        _MySpeed = Vector3.ClampMagnitude(_MySpeed + force, MaxSpeed);
    }

    public void FollowPath()
    {
        if (FollowWay.Count == 0) return;

        Vector3 nextPos = FollowWay[0].transform.position + Vector3.up * 1.5f;
        Vector3 dir = nextPos - transform.position;
        transform.forward = dir;
        transform.position += transform.forward * Time.deltaTime * _movementSpeed;
        if (dir.magnitude < 0.1f)
            FollowWay.RemoveAt(0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 lineA = GetVectorForAngle(-viewAngle + transform.localEulerAngles.y);
        Vector3 lineB = GetVectorForAngle(viewAngle + transform.localEulerAngles.y);

        Gizmos.DrawLine(transform.position, transform.position + lineA * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + lineB * viewRadius);
    }

    private Vector3 GetVectorForAngle(float Angle)
    {
        return new Vector3(Mathf.Sin(Angle * Mathf.Deg2Rad), 0, Mathf.Cos(Angle * Mathf.Deg2Rad));
    }

    public bool Fov(Vector3 pos)
    {
        Vector3 dir = pos - transform.position;
        if (dir.magnitude > viewRadius) return false;
        if (Physics.Raycast(transform.position, dir, dir.magnitude, wallLayer)) return false;
        return Vector3.Angle(transform.forward, dir) <= (viewAngle / 2);
        
    }

    
}