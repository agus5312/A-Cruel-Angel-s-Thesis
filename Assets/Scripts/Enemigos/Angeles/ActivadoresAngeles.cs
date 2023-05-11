using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadoresAngeles : MonoBehaviour
{
    ControladorAngeles controlador;
    [SerializeField] int grupo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CambiaItems>())
        {
            controlador = FindObjectOfType<ControladorAngeles>();
            controlador.Activar(grupo);
        }
    }
}
