﻿using UnityEngine;
using System.Collections;

public class GoToPlayer : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake()
    {
        // Set up the references.
        player = GameObject.Find("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
            nav.SetDestination(player.position);
            nav.enabled = true;
    }
}