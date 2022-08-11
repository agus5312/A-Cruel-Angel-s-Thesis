using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Frogger2 : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;
    Vector3 posInicial;
    bool atacar;
    bool huir;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        atacar = false;
    }
    private void Start()
    {
        player = FindObjectOfType<CambiaItems>().gameObject.transform;
        posInicial = transform.position;

        huir = false;
    }

    private void Update()
    {
        if (atacar)
        {
            agent.SetDestination(player.position);
        } 
    }

    private void OnEnable()
    {
        atacar = true;
    }

    public void NoLight()
    {
        StopCoroutine(Correr());
        if (!huir)
        {
            atacar = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flash")
        {
            if (!huir)
                StartCoroutine(Correr());
        }

        if (other.tag == "Luz")
        {
            if (!huir)
                StartCoroutine(Correr());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Luz")
        {
            StopCoroutine(Correr());
            if (!huir)
            {
                atacar = true;
            }
        }
    }

    IEnumerator Correr()
    {
        atacar = false;
        agent.SetDestination(transform.position);
        yield return new WaitForSeconds(3);
        huir = true;
        agent.SetDestination(posInicial);
        agent.speed = 9f;
        yield return new WaitForSeconds(8);
        agent.speed = 7f;
        huir = false;
        gameObject.SetActive(false);
    }
}
