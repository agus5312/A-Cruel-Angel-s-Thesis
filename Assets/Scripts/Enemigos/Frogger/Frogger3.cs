using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class Frogger3 : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    [SerializeField] LayerMask targetMask;
    [SerializeField] LayerMask obstructionMask;

    public bool canSeePlayer;

    [SerializeField] AudioClip correr;
    [SerializeField] AudioClip gruñido;
    [SerializeField] AudioClip idle;
    CamaraDeMuerte camarademuerte;
    NavMeshAgent agent;
    Animator anim;
    AudioSource sonid;
    Vector3 targetC;
    bool detenido;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        sonid = GetComponent<AudioSource>();
        playerRef = FindObjectOfType<CambiaItems>().gameObject;
    }

    private void OnEnable()
    {
        StartCoroutine("FOWRoutine");
        StartCoroutine("ComeCloser");

        anim.SetInteger("Estado", 1);

        sonid.clip = correr;
        sonid.Play();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator FOWRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    IEnumerator ComeCloser()
    {
        Close();
        WaitForSeconds wait = new WaitForSeconds(10f);

        while (true)
        {
            yield return wait;
            Close();
        }
    }

    IEnumerator Haunting()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            Haunt();
        }
    }

    IEnumerator Chasing()
    {
        anim.SetInteger("Estado", 1);
        sonid.clip = gruñido;
        sonid.Play();
        yield return new WaitForSeconds(2);
        sonid.clip = correr;
        sonid.Play();
        yield return new WaitForSeconds(13);
        StopCoroutine("Haunting");
        yield return new WaitForSeconds(0.4f);
        agent.isStopped = true;
        anim.SetTrigger("Abrir");
        anim.SetInteger("Estado", 0);
        sonid.clip = gruñido;
        sonid.Play();
        yield return new WaitForSeconds(4);
        agent.isStopped = false;
        sonid.clip = correr;
        anim.SetInteger("Estado", 1);
        sonid.Play();
        StartCoroutine("FOWRoutine");
        StartCoroutine("ComeCloser");
    }

    void Haunt()
    {
        agent.SetDestination(playerRef.transform.position);
    }

    void Close()
    {
        targetC = new Vector3(playerRef.transform.position.x + Random.Range(-25, 25), playerRef.transform.position.y, playerRef.transform.position.z + Random.Range(-25, 25));
        agent.SetDestination(targetC);
        anim.SetInteger("Estado", 1);
        sonid.clip = correr;
        sonid.Play();
    }

    void FieldOfViewCheck()
    {
        if (Vector3.Distance(targetC, transform.position) < 1)
        {
            if (!detenido)
            {
                anim.SetInteger("Estado", 0);
                sonid.clip = idle;
                sonid.Play();
                detenido = true;
            }
        }
        else
            detenido = false;


        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    StopAllCoroutines();
                    StartCoroutine("Haunting");
                    StartCoroutine("Chasing");
                }
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

    public void Deshabilitar(Vector3 pos)
    {
        StopAllCoroutines();
        anim.SetInteger("Estado", 1);
        sonid.clip = correr;
        sonid.Play();
        agent.SetDestination(pos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camarademuerte = FindObjectOfType<CamaraDeMuerte>();
            camarademuerte.Muerte();
            gameObject.SetActive(false);
        }
    }

}
