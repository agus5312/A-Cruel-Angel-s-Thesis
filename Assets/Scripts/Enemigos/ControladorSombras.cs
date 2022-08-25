using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSombras : MonoBehaviour
{
    public GameObject[] sombras;
    int i = 0;
    public void Cambio()
    {
        i++;
        if (i == sombras.Length)
        {
            gameObject.SetActive(false);
        }
        else
            sombras[i].SetActive(true);
    }
        
}
