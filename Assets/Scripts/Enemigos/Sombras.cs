using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombras : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Material mat;
    float distancia = 0;
    int i = 0;
    int a = 0;
    public Vector3[] sombrasPos;
    public AudioClip[] sombrasSon;
    InformacionGuardar informacion;
    AudioSource audi;
    bool cambioActivo = false;

    private void Start()
    {
        audi = GetComponent<AudioSource>();
        StartCoroutine(Voces());
        mat.SetFloat("_OutOffHeights",-2);
    }

    private void Update()
    {
        distancia = Vector3.Distance(transform.position, player.transform.position);
        if (distancia < 15 && !cambioActivo)
        {
            //Cambio();
            StartCoroutine(Cambio1());
            cambioActivo = true;
        }
        transform.LookAt(player.transform);
    }


    public void Cambio()
    {
        i++; 
        if (i == sombrasPos.Length)
        {
            informacion = FindObjectOfType<InformacionGuardar>();
            informacion.sombras = true;
            gameObject.SetActive(false);
        }
        else
            transform.position = sombrasPos[i];
    }
    IEnumerator Cambio1()
    {
        for (int i = 0; i < 40; i++)
        {
            yield return new WaitForSeconds(0.025f);
            float a = mat.GetFloat("_OutOffHeights");
            mat.SetFloat("_OutOffHeights", a + 0.075f);
        }
        i++;
        if (i == sombrasPos.Length)
        {
            informacion = FindObjectOfType<InformacionGuardar>();
            informacion.sombras = true;
            gameObject.SetActive(false);
        }
        else
            transform.position = sombrasPos[i];
        for (int i = 0; i < 40; i++)
        {
            yield return new WaitForSeconds(0.025f);
            float a = mat.GetFloat("_OutOffHeights");
            mat.SetFloat("_OutOffHeights", a - 0.075f);
        }
        cambioActivo = false;
    }
    IEnumerator Voces()
    {
        yield return new WaitForSeconds(10);
        a++;
        if (a == 5)
        {
            a = 0;
        }
        audi.clip = sombrasSon[a];
        audi.Play();
        StartCoroutine(Voces());
    }
}
