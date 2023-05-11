using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemigosEC : MonoBehaviour
{
    MuerteSombras muerte;
    EventoCabaņa evento;
    private void Start()
    {
        muerte = FindObjectOfType<MuerteSombras>();
        evento = FindObjectOfType<EventoCabaņa>();
    }

    private void OnEnable()
    {
        StartCoroutine(Tiempo());
    }

    IEnumerator Tiempo()
    {
        yield return new WaitForSeconds(10f);
        evento.StopCoroutine("Time");
        muerte.Muerte();
        print("Perdiste");
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flash"))
        {
            StopCoroutine(Tiempo());
            gameObject.SetActive(false);
        }
    }
}
