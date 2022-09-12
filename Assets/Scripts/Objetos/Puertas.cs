using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public TipoLllave tipo;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void AbrirPuerta()
    {
        anim.SetTrigger("Cambio");
    }

}
