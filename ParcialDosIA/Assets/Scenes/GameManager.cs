using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<PlayerMovement> Player = new List<PlayerMovement>();

    private Node _startingNode;

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
    }
    

}
