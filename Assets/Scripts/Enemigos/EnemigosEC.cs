using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemigosEC : MonoBehaviour
{
    MuerteSombras muerte;
    EventoCaba�a evento;
    private void Start()
    {
        muerte = FindObjectOfType<MuerteSombras>();
        evento = FindObjectOfType<EventoCaba�a>();
    }

    private void OnEnable()
    {
        StartCoroutine(Tiempo());
    }

    IEnumerator Tiempo()
    {
        yield return new WaitForSeconds(6f);
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
