using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorEventoCabaña : MonoBehaviour
{
    EventoCabaña evento;
    private void Start()
    {
        evento = FindObjectOfType<EventoCabaña>();
    }
    private void OnDisable()
    {
        
        if (evento)
        {
            evento.Oleada();
        }
    }
}
