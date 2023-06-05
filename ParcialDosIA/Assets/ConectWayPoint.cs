using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConectWayPoint : WayPoint
{
    
    public float _connectiviyRadius = 50f;

    List<ConectWayPoint> _conections;
    public void Start()
    {
        GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        _conections = new List<ConectWayPoint>();

        for (int i = 0; i < allWaypoints.Length; i++)
        {
          ConectWayPoint nextwaypoint = allWaypoints[i].GetComponent<ConectWayPoint>();
            if(nextwaypoint!=null)
            {
                if (Vector3.Distance(this.transform.position, nextwaypoint.transform.position) <= _connectiviyRadius && nextwaypoint!=this)
                {
                    _conections.Add(nextwaypoint);
                }
            }

        }
    }

    public override void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugDranRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _connectiviyRadius);

    }

    public ConectWayPoint NextWayPoint(ConectWayPoint previousWayPoint)
    {
        if (_conections.Count==0)
        {
            return null;
        }
        else if(_conections.Count==1 && _conections.Contains(previousWayPoint))
        {
            return previousWayPoint;
        }
        else
        {
            ConectWayPoint nextWayPonint;
            int nextIndex = 0;
            do
            {
                nextIndex = Random.Range(0, _conections.Count);
                nextWayPonint = _conections[nextIndex];
            } while (nextWayPonint == previousWayPoint);
            return nextWayPonint;

        }
    }
}
