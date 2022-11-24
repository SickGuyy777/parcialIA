using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //public List<EnemyMg> MyFriends = new List<EnemyMg>();
    private PathFinding _pf = new PathFinding();
    private Node _startingNode;
    private Node _goalNode;
    public Waypoints Enemies;
    public LayerMask wallLayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetStartingNode(Node n)
    {
        _startingNode = n;
        if (Enemies) Enemies.SetStartNode(n);
    }

    public void SetGoalNode(Node node)
    {
        _goalNode = node;
        if (Enemies) Enemies.goalNode = node;
    }

}
