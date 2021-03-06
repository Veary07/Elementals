﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour {


    [SerializeField] Transform[] teamOneStartingSpawns;
    [SerializeField] Transform[] teamTwoStartingSpawns;
    [SerializeField] Monolith teamOneMonolith;
    [SerializeField] Monolith teamTwoMonolith;

    [SerializeField] List<Monolith> teamOneSpawn;
    [SerializeField] List<Monolith> teamTwoSpawn;

    //public Monolith monolith;

    // Use this for initialization
    void Start ()
    {
        teamOneSpawn.Clear();
        teamTwoSpawn.Clear();
        for (int i = 0; i < teamOneStartingSpawns.Length; i++)
        {
            teamOneSpawn.Add(Instantiate(teamOneMonolith, teamOneStartingSpawns[i].transform.position, Quaternion.identity));
        }
        for (int i = 0; i < teamTwoStartingSpawns.Length; i++)
        {
            teamTwoSpawn.Add(Instantiate(teamTwoMonolith, teamTwoStartingSpawns[i].transform.position, Quaternion.identity));
        }

        for (int i = 0; i < teamOneSpawn.Count - 1; i++)
        {
            teamOneSpawn[i].GetComponent<Monolith>().SetDamageableOff();
        }

        for (int i = 0; i < teamTwoSpawn.Count - 1; i++)
        {
            teamTwoSpawn[i].GetComponent<Monolith>().SetDamageableOff();
        }
    }


    public void AddMonolithToListOne(Monolith Monolith)
    {
        teamOneSpawn.Add(Monolith);
    }
    public void AddMonolithToListTwo(Monolith Monolith)
    {
        teamTwoSpawn.Add(Monolith);
    }


    public Transform GetMonolith(int team)
    {
        if (team == 1)
        {
            return teamOneSpawn[teamOneSpawn.Count - 2].GetSpawner();
        }
        else if (team == 2)
        {
            return teamTwoSpawn[teamTwoSpawn.Count - 2].GetSpawner();
        }
        else
        {
            return null;
        }
    }

    public void RemoveMonolith(int team)
    {
        if (team == 1)
        {
            teamOneSpawn.Remove(teamOneSpawn[teamOneSpawn.Count - 1]);
            //teamOneSpawn[teamOneSpawn.Count - 1].GetComponent<HealthManager>().SetDamageableOn();
        }

        if (team == 2)
        {
            teamTwoSpawn.Remove(teamTwoSpawn[teamTwoSpawn.Count - 1]);
           // teamTwoSpawn[teamOneSpawn.Count - 1].GetComponent<HealthManager>().SetDamageableOn();
        }
    }
}
