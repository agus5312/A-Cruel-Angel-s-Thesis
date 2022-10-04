using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicaInicial : MonoBehaviour
{
    [SerializeField] GameObject[] activables;
    PlayableDirector direc;
    InformacionGuardar informacion;
    void Start()
    {
        direc = GetComponent<PlayableDirector>();
        informacion = FindObjectOfType<InformacionGuardar>();
        StartCoroutine(Inicio());
        
    }

    IEnumerator Inicio()
    {
        for (int i = 0; i < activables.Length; i++)
        {
            activables[i].SetActive(false);
        }
        direc.Play();
        yield return new WaitForSeconds(10f);
        for (int i = 0; i < activables.Length; i++)
        {
            activables[i].SetActive(true);
        }
        gameObject.SetActive(false);
        informacion.cinematicaInicial = true;
    }
}
