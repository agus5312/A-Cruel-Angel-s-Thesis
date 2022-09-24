using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaySonido : MonoBehaviour
{
    /*[Header("Ambiente")]
    [SerializeField] AudioSource audioSourceAmbiente;
    [Space]*/
    [Header("Botones")]
    [SerializeField] AudioSource audioSourceBotones;


    //public void Musicalizar()
    //{
        //audioSourceAmbiente.Play();
    //}
    public void SonidoBotones()
    {
        audioSourceBotones.Play();
    }
}
