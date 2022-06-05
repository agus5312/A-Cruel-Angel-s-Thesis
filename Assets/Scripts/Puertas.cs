using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public string tipo;
    bool cerrada;
    Animator anim;

    private void Start()
    {
        cerrada = true;
        anim = GetComponent<Animator>();
    }
    public void AbrirPuerta()
    {
        anim.SetTrigger("Cambio");
    }

}
