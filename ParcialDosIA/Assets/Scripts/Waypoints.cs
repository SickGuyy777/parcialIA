using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public GameObject[] allWaypoints;
    public LayerMask wallLayer;
    public Transform playerPrefab;
    public Node startingNode;
    public Node goalNode;
    public float speedRot;
    public float viewRadius;
    public float viewAngle;
    public PlayerMovement pl;
    Vector3 _lastPosPlayer;
    bool _notificationSee;
    int _currentWay = 0;
    float _movementSpeed = 8f;

    private void Update()
    {
        Movement();
    }

    public void SetStartNode(Node n)
    {
        startingNode = n;
        transform.position = startingNode.transform.position + Vector3.up * 1.5f;
    }

    public void Movement()
    {
        if (Fov(playerPrefab.transform.position))
        {
            var dire = playerPrefab.position - transform.position;
            var lerpDir = Vector3.Lerp(transform.forward, dire, Time.deltaTime * speedRot);
            transform.forward = lerpDir;
            var _Distancia = Vector3.Distance(playerPrefab.position, transform.position);
            _notificationSee = true;
            if (_notificationSee == true)
            {
                _lastPosPlayer = pl.transform.position;
            }
            if (_Distancia > 0.79)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerPrefab.position.x, transform.position.y, playerPrefab.position.z), _movementSpeed * Time.deltaTime);
            }
        }
        else
        {
            GameObject waypoint = allWaypoints[_currentWay];
            Vector3 dir = waypoint.transform.position - transform.position;//INLOS
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