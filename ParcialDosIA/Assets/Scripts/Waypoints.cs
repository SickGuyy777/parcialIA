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
    //public GameObject[] allWaypoints;
    //public Transform playerPrefab;
    //public PlayerMovement pl;
    //public Node startingNode;
    //public Node goalNode;
    //List<Node> FollowWay = new List<Node>();
    //PathFinding _Pathf = new PathFinding();
    //public Fsm StateMachine;
    //public float speedRot;
    //public float viewRadius;
    //public float viewAngle;
    //int _currentWay = 0;
    //public float _movementSpeed;
    //private bool Notify = false;
    //public float MaxForceRot;
    //public LayerMask wallLayer;
    //private Vector3 _MySpeed;

    //private void Start()
    //{
    //    GameManager.Instance.AddHuntter(this);
    //    StateMachine = new Fsm();
    //    var Patrol = new PatrolState(StateMachine, this);
    //    var ChaseState = new ChaseState(StateMachine, this);
    //    StateMachine.AddStatesInDiccionary(States.Idle, Idle);//agregamos todos los estados que pueda tener
    //    StateMachine.AddStatesInDiccionary(States.Patrol, Patrol);
    //    StateMachine.AddStatesInDiccionary(States.Chase, ChaseState);
    //    StateMachine.ChangeState(States.Patrol);//le decimos cual es su estado principal para que inicie
    //}
    //private void Update()
    //{
    //    Movement();
    //    StateMachine.ArtificialUpdate();//para que cambie su estado constantemente
    //    transform.position += _MySpeed * Time.deltaTime;
    //    transform.forward = _MySpeed;
    //}

    //public Vector3 GetMySpeed()//para que pueda obtener my vector que transforma mi posicion
    //{
    //    return _MySpeed;
    //}

    //public void Movement()
    //{
    //    if (Fov(playerPrefab.transform.position))
    //    {
    //        var dire = playerPrefab.position - transform.position;
    //        var lerpDir = Vector3.Lerp(transform.forward, dire, Time.deltaTime * speedRot);
    //        transform.forward = lerpDir;
    //        var _Distancia = Vector3.Distance(playerPrefab.position, transform.position);
    //        Notify = true;
    //        if (_Distancia > 0.79)
    //        {
    //            transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerPrefab.position.x, transform.position.y, playerPrefab.position.z), _movementSpeed * Time.deltaTime);
    //        }
    //        if (Notify==true)
    //        {
    //            foreach (Waypoints Hunters in GameManager.Instance.Hunters)
    //            {
    //                if (Hunters == this)
    //                {
    //                    continue;
    //                }
    //                else
    //                {
    //                    FollowWay = _Pathf.AStar(startingNode, goalNode);
    //                    if(FollowWay.Count!=0)
    //                    {
    //                        FollowPath();
    //                    }
    //                }
    //            }
    //        }

    //    }
    //    else
    //    {
    //        FollowWay = _Pathf.AStar(startingNode, goalNode);
    //        if (FollowWay.Count != 0)
    //        {
    //            FollowPath();
    //        }
    //        GameObject waypoint = allWaypoints[_currentWay];
    //        Vector3 dir = waypoint.transform.position - transform.position;
    //        dir.y = 0;
    //        transform.forward = dir;
    //        transform.position += transform.forward * _movementSpeed * Time.deltaTime;

    //        if (dir.magnitude <= 0.3f)
    //        {
    //            _currentWay++;
    //            if (_currentWay > allWaypoints.Length - 1)
    //            {
    //                _currentWay = 0;
    //            }
    //        }
            
    //    }
    //}

    //public Vector3 SteeringCalculate(Vector3 Desired)
    //{
    //    return Vector3.ClampMagnitude((Desired.normalized * _movementSpeed) - _MySpeed, MaxForceRot);
    //}

    //public void MyForce(Vector3 force)
    //{
    //    _MySpeed = Vector3.ClampMagnitude(_MySpeed + force, _movementSpeed);
    //}

    //void FollowPath()
    //{
    //    if (FollowWay.Count == 0) return;

    //    Vector3 nextPos = FollowWay[0].transform.position + Vector3.up * 1.5f;
    //    Vector3 dir = nextPos - transform.position;
    //    transform.forward = dir;
    //    transform.position += transform.forward * Time.deltaTime * _movementSpeed;

    //    if (dir.magnitude < 0.1f)
    //        FollowWay.RemoveAt(0);
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, viewRadius);

    //    Vector3 lineA = GetVectorForAngle(-viewAngle + transform.localEulerAngles.y);
    //    Vector3 lineB = GetVectorForAngle(viewAngle + transform.localEulerAngles.y);

    //    Gizmos.DrawLine(transform.position, transform.position + lineA * viewRadius);
    //    Gizmos.DrawLine(transform.position, transform.position + lineB * viewRadius);
    //}

    //private Vector3 GetVectorForAngle(float Angle)
    //{
    //    return new Vector3(Mathf.Sin(Angle * Mathf.Deg2Rad), 0, Mathf.Cos(Angle * Mathf.Deg2Rad));
    //}
}