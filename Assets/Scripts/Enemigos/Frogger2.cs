using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Frogger2 : MonoBehaviour
{
    CamaraDeMuerte camarademuerte;
    NavMeshAgent agent;
    Transform player;
    Animator anim;
    Vector3 posInicial;
    bool atacar;
    bool huir;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        atacar = false;
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        player = FindObjectOfType<CambiaItems>().gameObject.transform;
        posInicial = transform.position;
        huir = false;
        anim.SetTrigger("Caminar");
        camarademuerte = FindObjectOfType<CamaraDeMuerte>();
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
        huir = false;
        anim.SetTrigger("Caminar");
    }

    public void NoLight()
    {
        if (!huir)
        {
            StopCoroutine(Correr());
            anim.SetTrigger("Caminar");
            atacar = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camarademuerte.Muerte();
            gameObject.SetActive(false);
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
            
            if (!huir)
            {
                StopCoroutine(Correr());
                atacar = true;
                anim.SetTrigger("Caminar");
            }
        }
    }

    IEnumerator Correr()
    {
        atacar = false;
        agent.SetDestination(transform.position);
        anim.SetTrigger("Defenderse");
        yield return new WaitForSeconds(3);
        huir = true;
        agent.SetDestination(posInicial);
        anim.SetTrigger("Caminar");
        agent.speed = 9f;
        yield return new WaitForSeconds(8);
        agent.speed = 7f;
        huir = false;
        gameObject.SetActive(false);
    }
}
