using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EventoLago : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;
    bool noEmpezo = true;
    Animator anim;
    [SerializeField] Vector3 pos;
    [SerializeField] GameObject contEnemigos;
    InformacionGuardar infoPartida;

    void Start()
    {
        player = FindObjectOfType<CambiaItems>().gameObject.transform;
        infoPartida = FindObjectOfType<InformacionGuardar>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Vector3.Distance(player.position, transform.position) < 15)
        {
            if (noEmpezo)
            {
                StartCoroutine(Comenzar());
                noEmpezo = false;
            }
        }  
    }

    IEnumerator Comenzar()
    {
        infoPartida.froggers = true;
        transform.LookAt(player);
        anim.SetTrigger("Defender");
        yield return new WaitForSeconds(2);
        anim.SetTrigger("Caminar");
        agent.SetDestination(pos);
        yield return new WaitForSeconds(15);
        contEnemigos.SetActive(true);
        gameObject.SetActive(false);
    }
}
