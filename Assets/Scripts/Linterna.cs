using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public GameObject luz;
    bool encendida;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (encendida == true)
            {
                luz.SetActive(false);
                encendida = false;
            }
            else
            {
                luz.SetActive(true);
                encendida = true;
            }
        }
    }
}
