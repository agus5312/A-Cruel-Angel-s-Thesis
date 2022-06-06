using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    GameObject luzLinterna;

    private void Start()
    {
        luzLinterna = GameObject.FindGameObjectWithTag("Luz");
        luzLinterna.SetActive(false);
        StartCoroutine(PrenderLinterna(Random.Range(0.1f, 2)));
    }

    IEnumerator PrenderLinterna(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        luzLinterna.SetActive(true);
        StartCoroutine(ApagarLinterna(Random.Range(0.1f,2)));
    }

    IEnumerator ApagarLinterna(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        luzLinterna.SetActive(false);
        StartCoroutine(PrenderLinterna(Random.Range(0.1f, 2)));
    }
}
