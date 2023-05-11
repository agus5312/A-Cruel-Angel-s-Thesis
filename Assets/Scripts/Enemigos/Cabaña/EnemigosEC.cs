using System.Collections;
<<<<<<< Updated upstream
using System.Collections.Generic;
using UnityEngine.SceneManagement;
=======
>>>>>>> Stashed changes
using UnityEngine;

public class EnemigosEC : MonoBehaviour
{
    MuerteSombras muerte;
    EventoCabaña evento;
<<<<<<< Updated upstream
=======
    [SerializeField] Material mat;
    bool desapareciendo;
>>>>>>> Stashed changes
    private void Start()
    {
        muerte = FindObjectOfType<MuerteSombras>();
        evento = FindObjectOfType<EventoCabaña>();
    }

    private void OnEnable()
    {
        StartCoroutine(Tiempo());
<<<<<<< Updated upstream
=======
        desapareciendo = false;
        StartCoroutine(Aparicion());
>>>>>>> Stashed changes
    }

    IEnumerator Tiempo()
    {
        yield return new WaitForSeconds(10f);
        evento.StopCoroutine("Time");
        muerte.Muerte();
<<<<<<< Updated upstream
        print("Perdiste");
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flash"))
        {
            StopCoroutine(Tiempo());
            gameObject.SetActive(false);
=======
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
>>>>>>> Stashed changes
        }
    }
}
