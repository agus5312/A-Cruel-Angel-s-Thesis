using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzLinterna : MonoBehaviour
{
    Frogger2 enemigo;
    private void OnEnable()
    {
        enemigo = FindObjectOfType<Frogger2>();
    }
    private void OnDisable()
    {
        if(enemigo != null)
        enemigo.NoLight();
    }
}
