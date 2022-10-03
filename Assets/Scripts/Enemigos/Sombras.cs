using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombras : MonoBehaviour
{
    GameObject player;
    float distancia = 0;
    int i = 0;
    public Vector3[] sombrasPos;
    InformacionGuardar informacion;

    private void Start()
    {
        player = FindObjectOfType<CambiaItems>().gameObject;
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
}
