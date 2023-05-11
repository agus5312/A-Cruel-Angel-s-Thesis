using System.Collections;
using UnityEngine;

public class EnemigosEC : MonoBehaviour
{
    MuerteSombras muerte;
    EventoCabaña evento;
    [SerializeField] Material mat;
    bool desapareciendo;
    private void Start()
    {
        muerte = FindObjectOfType<MuerteSombras>();
        evento = FindObjectOfType<EventoCabaña>();
    }

    private void OnEnable()
    {
        StartCoroutine(Tiempo());
        desapareciendo = false;
        StartCoroutine(Aparicion());
    }

    IEnumerator Tiempo()
    {
        yield return new WaitForSeconds(10f);
        evento.StopCoroutine("Time");
        muerte.Muerte();
    }

    IEnumerator Aparicion()
    {
        mat.SetFloat("_OutOffHeights", 11);
        for (int i = 0; i < 40; i++)
        {
            yield return new WaitForSeconds(0.025f);
            float a = mat.GetFloat("_OutOffHeights");
            mat.SetFloat("_OutOffHeights", a - 0.25f);
        }
    }

    IEnumerator Desaparicion()
    {
        mat.SetFloat("_OutOffHeights", 1);
        for (int i = 0; i < 40; i++)
        {
            yield return new WaitForSeconds(0.025f);
            float a = mat.GetFloat("_OutOffHeights");
            mat.SetFloat("_OutOffHeights", a + 0.25f);
        }
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flash") && !desapareciendo)
        {
            StopAllCoroutines();
            desapareciendo = true;
            StartCoroutine(Desaparicion());
        }
    }
}
