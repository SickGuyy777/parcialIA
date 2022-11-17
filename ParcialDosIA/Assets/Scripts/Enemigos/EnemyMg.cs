using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMg : MonoBehaviour
{
    public float ViewRadius;
    public float ViewAngle;
    public float speedRot;
    public float speed;
    public LayerMask WallMask;
    public Transform jugador;
    public GameObject Player;
    void Start()
    {

        //var dir = jugador.position - transform.position;
        //var lerpDir = Vector3.Lerp(transform.forward, dir, Time.deltaTime * speedRot);
        //transform.forward = lerpDir;
        //var _Distancia = Vector3.Distance(jugador.position, transform.position);
        //if (_Distancia > 0.79)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, new Vector3(jugador.position.x, transform.position.y, jugador.position.z), speed * Time.deltaTime);
        //} 
    }

    // Update is called once per frame
    void Update()
    {

            if (Fov(Player.transform.position))
            {
                
            }
        
    }


    bool Fov(Vector3 pos)
    {
        Vector3 dir = pos - transform.position;
        if (dir.magnitude> ViewRadius)return false;
        if (Physics.Raycast(transform.position, dir, dir.magnitude, WallMask)) return false;
        return Vector3.Angle(transform.forward, dir) <=(ViewAngle/2);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ViewRadius);

        Vector3 lineA = GetVectorForAngle(-ViewAngle + transform.localEulerAngles.y);
        Vector3 lineB = GetVectorForAngle(ViewAngle + transform.localEulerAngles.y);

        Gizmos.DrawLine(transform.position, transform.position + lineA*ViewRadius);
        Gizmos.DrawLine(transform.position, transform.position + lineB*ViewRadius);
    }
    private Vector3 GetVectorForAngle(float Angle)
    {
        return new Vector3(Mathf.Sin(Angle * Mathf.Deg2Rad), 0, Mathf.Cos(Angle * Mathf.Deg2Rad));
    }
}
