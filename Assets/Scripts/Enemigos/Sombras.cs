using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombras : MonoBehaviour
{
    GameObject player;
    ControladorSombras cont;
    float distancia = 0;
    private void Start()
    {
        player = FindObjectOfType<CambiaItems>().gameObject;
        cont = FindObjectOfType<ControladorSombras>();
    }

    private void Update()
    {
        distancia = Vector3.Distance(transform.position, player.transform.position);
        if (distancia < 15)
        {
            gameObject.SetActive(false);
            cont.Cambio();
        }
        transform.LookAt(player.transform);
    }
}
