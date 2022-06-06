using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Frogger : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    public bool encendida;
    bool cerca;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        encendida = false;
        cerca = false;
    }
    private void Update()
    {
        if (encendida && cerca)
        {
            agent.SetDestination(transform.position);
        }
        else if (cerca)
        {
            agent.SetDestination(player.position);
            
        }
    }

    public void NoLight()
    {
        encendida = false;
        StopCoroutine(Correr());
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flash")
        {
            StartCoroutine(Correr());
            encendida = true;
        }

        if (other.tag == "Luz")
        {
            encendida = true;
            StartCoroutine(Correr());
        }

        if (other.tag == "Player")
        {
            agent.SetDestination(player.position);
            
            cerca = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Luz")
        {
            encendida = false;
            StopCoroutine(Correr());
        }

        if (other.tag == "Player")
        {
            cerca = false;
            StartCoroutine(Correr());
        }
    }

    IEnumerator Correr()
    {
        yield return new WaitForSeconds(4);
        agent.speed = 7;
        agent.SetDestination(new Vector3(transform.position.x -50, transform.position.y, transform.position.z -50));
        cerca = false;
        encendida = false;
        yield return new WaitForSeconds(15);
        agent.speed = 3;
        agent.SetDestination(transform.position);
    }

}
