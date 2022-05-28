using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoEnSuelo : MonoBehaviour
{
    public GameObject indicador;

    private void OnMouseEnter()
    {
        indicador.SetActive(true);
    }

    private void OnMouseExit()
    {
        indicador.SetActive(false);
    }

    private void OnDestroy()
    {
        indicador.SetActive(false);
    }
}
