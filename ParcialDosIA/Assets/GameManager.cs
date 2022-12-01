using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Waypoints> Hunters = new List<Waypoints>();
    public List<PlayerMovement> Player = new List<PlayerMovement>();
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

    public void AddHuntter(Waypoints Hunt)
    {
        if (!Hunters.Contains(Hunt))
        {
            Hunters.Add(Hunt);
        }
    }

    public void AddPlayer(PlayerMovement Pl)
    {
        if (!Player.Contains(Pl))
        {
            Player.Add(Pl);
        }
    }

}
