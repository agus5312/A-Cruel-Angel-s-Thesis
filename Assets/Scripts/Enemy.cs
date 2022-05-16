using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.SetDestination(player.position);
    }
}
