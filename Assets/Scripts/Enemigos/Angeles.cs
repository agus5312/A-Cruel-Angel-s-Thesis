using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Angeles : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    bool atacar;

    private void Start()
    {
        atacar = false;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (atacar)
        {
            agent.SetDestination(player.position);
        }
    }
    private void OnBecameVisible()
    {
        atacar = false;
        agent.SetDestination(transform.position);
    }

    private void OnBecameInvisible()
    {
        atacar = true;
    }
}
