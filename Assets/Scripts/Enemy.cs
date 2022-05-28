using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    public bool encendida;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        encendida = false;
    }
    private void Update()
    {
        if (encendida)
        {
            agent.SetDestination(transform.position);
        }
        else
        {
            agent.SetDestination(player.position);
        }
    }

    public void NoLight()
    {
        encendida = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flash")
        {
            StartCoroutine(Flash());
        }

        if (other.tag == "Luz")
        {
            encendida = true;
        }
    }

    IEnumerator Flash()
    {
        encendida = true;
        yield return new WaitForSeconds(4);
        encendida = false;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Luz")
        {
            encendida = false;
        }
    }
}
