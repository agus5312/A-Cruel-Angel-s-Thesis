using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CartelIndicador : MonoBehaviour
{
    Text texto;
    PlayableDirector direc;
    private void Start()
    {
        direc = GetComponent<PlayableDirector>();
        texto = GetComponent<Text>();
    }

    public void Aparecer(string text)
    {
        texto.text = text;
        direc.Play();
    }

}
