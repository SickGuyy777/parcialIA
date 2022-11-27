using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IuFuntions
{
    private Fsm _Fsm;
    private Waypoints Hunter;
    public void OnEnter()
    {
        
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
        
    }


    //bool Fov(Vector3 pos)
    //{
    //    Vector3 dir = pos - Hunter.transform.position;
    //    if (dir.magnitude >Hunter.viewRadius) return false;
    //    if (Physics.Raycast(Hunter.transform.position, dir, dir.magnitude, Hunter.wallLayer)) return false;
    //    return Vector3.Angle(Hunter.transform.forward, dir) <= (Hunter.viewAngle / 2);
    //}
}
