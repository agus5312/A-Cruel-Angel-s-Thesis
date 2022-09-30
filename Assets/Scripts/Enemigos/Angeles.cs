using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Angeles : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;
    bool atacar;
    AudioSource audi;
    [SerializeField] AudioClip clip1;
    [SerializeField] AudioClip clip2;
    [SerializeField] AudioClip clip3;

    private void Start()
    {
        atacar = false;
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<CambiaItems>().transform;
        audi = GetComponent<AudioSource>();
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
        if (this.enabled)
        {
            atacar = false;
            audi.Stop();
            agent.isStopped = true;
        }
    }

    private void OnBecameInvisible()
    {
        if (this.enabled)
        {
            atacar = true;
            int i = Random.Range(0, 3);
            switch (i)
            {
                case 0:
                    audi.clip = clip1;
                    break;
                case 1:
                    audi.clip = clip2;
                    break;
                case 2:
                    audi.clip = clip3;
                    break;
            }
            audi.Play();
            agent.isStopped = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.enabled && other.GetComponent<CambiaItems>())
        {
            MuerteAngeles muerte = FindObjectOfType<MuerteAngeles>();
            muerte.Muerte();
        }
    }

    private void OnDisable()
    {
        if (this)
        {
            if(agent) agent.isStopped = true;
            audi.Stop();
        }
    }
}
