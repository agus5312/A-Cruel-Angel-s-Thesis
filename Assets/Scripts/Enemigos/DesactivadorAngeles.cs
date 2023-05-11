using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivadorAngeles : MonoBehaviour
{
    ControladorAngeles controlador;
    [SerializeField] int numero;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CambiaItems>())
        {
            controlador = FindObjectOfType<ControladorAngeles>();
            controlador.Desactivar(numero);
        }
    }
}
