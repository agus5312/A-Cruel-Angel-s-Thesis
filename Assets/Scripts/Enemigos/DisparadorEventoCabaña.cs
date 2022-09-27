using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorEventoCabaña : MonoBehaviour
{
    EventoCabaña evento;
    private void OnDisable()
    {
        evento = FindObjectOfType<EventoCabaña>();
        if (evento)
        {
            evento.Oleada();

        }
    }
}
