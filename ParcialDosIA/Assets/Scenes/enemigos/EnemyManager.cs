using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum States
{
    Idle,
    Patrol,
    Chase,
}
public class EnemyManager : MonoBehaviour
{
 private Vector3 _MySpeed;
 public GameObject Agent;
 //public Agent bots;
 public GameObject[] AllPatrollPoints;
 public LayerMask Enemys;
 public FSM StateMachine;
 public float MaxSpeed;
 public float MaxForceRot;
 public float VisionRadius;
 private float CurrentT;//tiempo
 private float MaxT = 3;//Max Tiempo
 public float MaxStamine;
 public float CurrentStamine;
 public bool FullStamine = true;
 public bool DetectPresa = false;
 public int ActualPatrolPoint;
 public float Speed;
    void Start()
    {
     CurrentStamine = MaxStamine;
     CurrentT = MaxT;
     StateMachine = new FSM();
     //var Idle = new IdleState(StateMachine, this);//los instanciamos dentro del codigo para que luego lo agreguemos a la maquina de estados que la fsm
     var Patrol = new PatrolState(StateMachine, this);
     var ChaseState = new ChaseState(StateMachine, this);
     //StateMachine.AddStatesInDiccionary(States.Idle, Idle);//agregamos todos los estados que pueda tener
     StateMachine.AddStatesInDiccionary(States.Patrol, Patrol);
     StateMachine.AddStatesInDiccionary(States.Chase, ChaseState);
     StateMachine.ChangeState(States.Idle);//le decimos cual es su estado principal para que inicie
    }

    public Vector3 GetMySpeed()//para que pueda obtener my vector que transforma mi posicion
    {
     return _MySpeed;
    }

    void Update()
    {
     DetectPresa = Physics.CheckSphere(transform.position, VisionRadius, Enemys);
     StateMachine.ArtificialUpdate();//para que cambie su estado constantemente
     transform.position += _MySpeed * Time.deltaTime;
     transform.forward = _MySpeed;
    }

    public Vector3 SteeringCalculate(Vector3 Desired)
    {
     return Vector3.ClampMagnitude((Desired.normalized * MaxSpeed) - _MySpeed, MaxForceRot);
    }

    public void MyForce(Vector3 force)
    {
     _MySpeed = Vector3.ClampMagnitude(_MySpeed + force, MaxSpeed);
    }

    private void OnDrawGizmos()
    {
     Gizmos.color = Color.red;
     Gizmos.DrawWireSphere(transform.position, VisionRadius);
    }

   
}
