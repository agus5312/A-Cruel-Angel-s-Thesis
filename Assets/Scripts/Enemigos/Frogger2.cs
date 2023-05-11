using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Frogger2 : MonoBehaviour
{
    [SerializeField] AudioClip correr;
    [SerializeField] AudioClip gruñido;
    CamaraDeMuerte camarademuerte;
    NavMeshAgent agent;
    Transform player;
    Animator anim;
    AudioSource sonid;
    Vector3 posInicial;
    bool atacar;
    bool huir;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        sonid = GetComponent<AudioSource>();

    }
    private void Start()
    {
        player = FindObjectOfType<CambiaItems>().gameObject.transform;
        posInicial = transform.position;
        anim.SetInteger("Estado", 1);
        camarademuerte = FindObjectOfType<CamaraDeMuerte>();
    }

    private void Update()
    {
        if (atacar && !huir)
        {
            agent.SetDestination(player.position);
        } 
    }

    private void OnEnable()
    {
        atacar = true;
        huir = false;
        anim.SetInteger("Estado", 1);
        sonid.clip = correr;
        sonid.Play();
    }

    public void NoLight()
    {
        if (!huir)
        {
            StopCoroutine(Correr());
            anim.SetInteger("Estado", 1);
            sonid.clip = correr;
            sonid.Play();
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
            {
                atacar = false;
                agent.SetDestination(transform.position);
                anim.SetInteger("Estado", 2);
                sonid.clip = gruñido;
                sonid.Play();
                StartCoroutine(Correr());
            }
        }

        if (other.tag == "Luz")
        {
            if (!huir)
            {
                atacar = false;
                agent.SetDestination(transform.position);
                anim.SetInteger("Estado", 2);
                sonid.clip = gruñido;
                sonid.Play();
                StartCoroutine(Correr());
            }
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
                anim.SetInteger("Estado", 1);
                sonid.clip = correr;
                sonid.Play();
            }
        }
    }

    IEnumerator Correr()
    {
        yield return new WaitForSeconds(3);
        huir = true;
        agent.SetDestination(posInicial);
        anim.SetInteger("Estado", 1);
        sonid.clip = correr;
        sonid.Play();
        agent.speed = 12f;
        yield return new WaitForSeconds(8);
        agent.speed = 14f;
        huir = false;
        gameObject.SetActive(false);
    }
}
