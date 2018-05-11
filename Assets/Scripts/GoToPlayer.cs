using UnityEngine;
using System.Collections;

public class GoToPlayer : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
    public float stopDistance;


    void Awake()
    {
        // Set up the references.
        player = GameObject.Find("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav.SetDestination(player.position);
    }


    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= stopDistance)
        {
            nav.enabled = false;
        }
        else
        {
            nav.enabled = true;
        }
    }
}