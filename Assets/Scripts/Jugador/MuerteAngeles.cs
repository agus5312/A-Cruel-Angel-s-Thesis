using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class MuerteAngeles : MonoBehaviour
{
    [SerializeField] GameObject camaraPrincpal;
    [SerializeField] GameObject camara;
    [SerializeField] GameObject oscuro;
    [SerializeField] GameObject[] desactivados;
    PlayableDirector director;

    private void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    public void Muerte()
    {
        transform.position = camaraPrincpal.transform.position;
        transform.rotation = camaraPrincpal.transform.rotation;
        for (int i = 0; i < desactivados.Length; i++)
        {
            desactivados[i].SetActive(false);
        }
        camara.SetActive(true);
        director.Play();
        StartCoroutine(resetear());
    }

    private IEnumerator resetear()
    {
        yield return new WaitForSeconds(2f);
        oscuro.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Pruebas");
    }
}
