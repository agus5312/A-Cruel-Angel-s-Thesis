using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombras : MonoBehaviour
{
    [SerializeField] GameObject player;
    float distancia = 0;
    int i = 0;
    int a = 0;
    public Vector3[] sombrasPos;
    public AudioClip[] sombrasSon;
    InformacionGuardar informacion;
    AudioSource audi;

    private void Start()
    {
        audi = GetComponent<AudioSource>();
        StartCoroutine(Voces());
    }

    private void Update()
    {
        distancia = Vector3.Distance(transform.position, player.transform.position);
        if (distancia < 15)
        {
            Cambio();
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
