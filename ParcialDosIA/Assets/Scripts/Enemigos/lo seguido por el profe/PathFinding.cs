using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding
{
    //public List<Node> ThetaStar(Node startingNode, Node goalNode)
    //{
    //    if (startingNode == null || goalNode == null) return new List<Node>();

    //    List<Node> path = AStar(startingNode, goalNode);
    //    //Agregar starting Node si AStar no lo devuelve y se necesita. #opcional

    //    int current = 0;
    //    while (current + 2 < path.Count)
    //    {
    //        if (InLineOfSight(path[current].transform.position, path[current + 2].transform.position))
    //            path.RemoveAt(current + 1);
    //        else
    //            current++;
    //    }

    //    return path;
    //}

    //public bool InLineOfSight(Vector3 start, Vector3 end)
    //{
    //    //origen, direccion, distancia maxima, layer mask
    //    Vector3 dir = end - start;
    //    return !Physics.Raycast(start, dir, dir.magnitude, GameManager.Instance.wallLayer);
    //}


    //public List<Node> AStar(Node startingNode, Node goalNode)
    //{
    //    if (startingNode == null || goalNode == null) return new List<Node>();
    //    PriorityQueue<Node> frontier = new PriorityQueue<Node>();
    //    frontier.Enqueue(startingNode, 0);

    //    Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
    //    cameFrom.Add(startingNode, null);

    //    Dictionary<Node, int> costSoFar = new Dictionary<Node, int>();
    //    costSoFar.Add(startingNode, 0);

    //    while (frontier.Count > 0)
    //    {
    //        Node current = frontier.Dequeue();

    //        if (current == goalNode)
    //        {
    //            List<Node> path = new List<Node>();
    //            while (current != startingNode)
    //            {
    //                path.Add(current);
    //                current = cameFrom[current];
    //            }
    //            path.Add(startingNode); //Opcional
    //            path.Reverse();

    //            return path;
    //        }

    //        foreach (var next in current.GiveMeNeighbors())
    //        {
    //            if (next.isBlocked) continue;
    //            int newCost = costSoFar[current] + next.cost;
    //            float priority = newCost + Vector3.Distance(next.transform.position, goalNode.transform.position);
    //            if (!costSoFar.ContainsKey(next))
    //            {
    //                frontier.Enqueue(next, priority);
    //                cameFrom.Add(next, current);
    //                costSoFar.Add(next, newCost);
    //            }
    //            else if (newCost < costSoFar[next])
    //            {
    //                frontier.Enqueue(next, priority);
    //                cameFrom[next] = current;
    //                costSoFar[next] = newCost;
    //            }
    //        }
    //    }
    //    return new List<Node>();
    //}



    //public List<Node> GreedyBFS(Node startingNode, Node goalNode)
    //{
    //    if (startingNode == null || goalNode == null) return new List<Node>();

    //    PriorityQueue<Node> frontier = new PriorityQueue<Node>();
    //    frontier.Enqueue(startingNode, 0);

    //    Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
    //    cameFrom.Add(startingNode, null);

    //    while (frontier.Count > 0)
    //    {
    //        Node current = frontier.Dequeue();

    //        if (current == goalNode)
    //        {
    //            List<Node> path = new List<Node>();
    //            while (current != startingNode)
    //            {
    //                path.Add(current);
    //                current = cameFrom[current];
    //            }
    //            //path.append(start) # optional
    //            //path.reverse() # optional
    //            path.Reverse();
    //            return path;
    //        }

    //        foreach (var next in current.GetNeighbors())
    //        {
    //            if (next.isBlocked) continue;

    //            if (!cameFrom.ContainsKey(next))
    //            {
    //                frontier.Enqueue(next, Vector3.Distance(next.transform.position, goalNode.transform.position));
    //                cameFrom.Add(next, current);
    //            }
    //        }
    //    }
    //    return new List<Node>();
    //}




    //public List<Node> Dijkstra(Node startingNode, Node goalNode)
    //{
    //    if (startingNode == null || goalNode == null) return new List<Node>();

    //    PriorityQueue<Node> frontier = new PriorityQueue<Node>();
    //    frontier.Enqueue(startingNode, 0);

    //    Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
    //    cameFrom.Add(startingNode, null);

    //    Dictionary<Node, int> costSoFar = new Dictionary<Node, int>();
    //    costSoFar.Add(startingNode, 0);

    //    while (frontier.Count > 0)
    //    {
    //        Node current = frontier.Dequeue();

    //        if (current == goalNode)
    //        {
    //            List<Node> path = new List<Node>();
    //            while (current != startingNode)
    //            {
    //                path.Add(current);
    //                current = cameFrom[current];
    //            }
    //            path.Reverse();
    //            return path;
    //        }

    //        foreach (var next in current.GetNeighbors())
    //        {
    //            if (next.isBlocked) continue;
    //            int newCost = costSoFar[current] + next.cost;

    //            if (!costSoFar.ContainsKey(next))
    //            {
    //                frontier.Enqueue(next, newCost);
    //                cameFrom.Add(next, current);
    //                costSoFar.Add(next, newCost);
    //            }
    //            else if (newCost < costSoFar[next])
    //            {
    //                frontier.Enqueue(next, newCost);
    //                cameFrom[next] = current;
    //                costSoFar[next] = newCost;
    //            }
    //        }
    //    }
    //    return new List<Node>();
    //}


    ////Breadth First Search
    //public List<Node> BFS(Node startingNode, Node goalNode)
    //{
    //    if (startingNode == null || goalNode == null) return new List<Node>();

    //    Queue<Node> frontier = new Queue<Node>();
    //    frontier.Enqueue(startingNode);

    //    Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
    //    cameFrom.Add(startingNode, null);

    //    while (frontier.Count > 0)
    //    {
    //        Node current = frontier.Dequeue();

    //        if (current == goalNode)
    //        {
    //            List<Node> path = new List<Node>();
    //            while (current != startingNode)
    //            {
    //                path.Add(current);
    //                current = cameFrom[current];
    //            }
    //            //path.append(start) # optional
    //            //path.reverse() # optional
    //            path.Reverse();
    //            return path;
    //        }

    //        foreach (var next in current.GetNeighbors())
    //        {
    //            if (next.isBlocked) continue;

    //            if (!cameFrom.ContainsKey(next))
    //            {
    //                frontier.Enqueue(next);
    //                cameFrom.Add(next, current);
    //            }
    //        }
    //    }
    //    return new List<Node>();
    //}
}
