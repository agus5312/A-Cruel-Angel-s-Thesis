using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoEnSuelo : MonoBehaviour
{
    public GameObject indicador;
    GameObject player;
    public TipoObjeto type;

    private void Awake()
    {
        player = FindObjectOfType<CambiaItems>().gameObject;
    }
    private void OnMouseEnter()
    {
        if(Vector3.Distance(transform.position,player.transform.position) < 3)
        {
            indicador.SetActive(true);
        }
    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3)
        {
            indicador.SetActive(true);
        }
        else
        {
            indicador.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        indicador.SetActive(false);
    }
    private void OnDisable()
    {
        if (indicador)
        {
            indicador.SetActive(false);
        }
    }
}
