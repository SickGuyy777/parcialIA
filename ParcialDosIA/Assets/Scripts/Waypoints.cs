using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{   
    public GameObject[] allWaypoints;
    public Transform playerPrefab;
    public PlayerMovement pl;
    public Node startingNode;
    public Node goalNode;
    List<Node> FollowWay=new List<Node>();
    PathFinding _Pathf = new PathFinding();
    public float speedRot;
    public float viewRadius;
    public float viewAngle;
    int _currentWay = 0;
    public float _movementSpeed;
    private bool Notify = false;
    Vector3 _lastPosPlayer;
    public LayerMask wallLayer;

    private void Start()
    {
        GameManager.Instance.AddHuntter(this);
    }
    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if (Fov(playerPrefab.transform.position))
        {
            var dire = playerPrefab.position - transform.position;
            var lerpDir = Vector3.Lerp(transform.forward, dire, Time.deltaTime * speedRot);
            transform.forward = lerpDir;
            var _Distancia = Vector3.Distance(playerPrefab.position, transform.position);
            Notify = true;
            if(Notify==true)
            {
                foreach (Waypoints Hunters in GameManager.Instance.Hunters)
                {
                    if (Hunters == this)
                    {
                        continue;
                    }
                    else
                    {
                        FollowWay = _Pathf.BFS(startingNode, goalNode);
                    }
                }
            }
            if (_Distancia > 0.79)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerPrefab.position.x, transform.position.y, playerPrefab.position.z), _movementSpeed * Time.deltaTime);
            }
        }
        else
        {
            FollowWay = _Pathf.BFS(startingNode, goalNode);
            GameObject waypoint = allWaypoints[_currentWay];
            Vector3 dir = waypoint.transform.position - transform.position;
            dir.y = 0;
            transform.forward = dir;
            transform.position += transform.forward * _movementSpeed * Time.deltaTime;

            if (dir.magnitude <= 0.3f)
            {
                _currentWay++;
                if (_currentWay > allWaypoints.Length - 1)
                {
                    _currentWay = 0;
                }
            }
            
        }
    }
    void FollouPath()
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

    bool Fov(Vector3 pos)
    {
        Vector3 dir = pos - transform.position;
        if (dir.magnitude > viewRadius) return false;
        if (Physics.Raycast(transform.position, dir, dir.magnitude, wallLayer)) return false;
        return Vector3.Angle(transform.forward, dir) <= (viewAngle / 2);
    }

    private Vector3 GetVectorForAngle(float Angle)
    {
        return new Vector3(Mathf.Sin(Angle * Mathf.Deg2Rad), 0, Mathf.Cos(Angle * Mathf.Deg2Rad));
    }
}