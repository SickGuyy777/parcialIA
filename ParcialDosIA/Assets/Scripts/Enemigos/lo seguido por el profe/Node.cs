using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> _neighbors = new List<Node>();
    public int cost = 1;
    public int _coste;
    private void Start()
    {
        SetCost(_coste);
    }
    public List<Node> GetNeighbors()
    {
        foreach (var item in _neighbors)
        {
            _neighbors.Add(item);
            
        }
        return _neighbors;
    }
    void SetCost(int c)
    {
        cost = Mathf.Clamp(c, 1, 99);
    }
    void CosteNode()
    {

    }
}
