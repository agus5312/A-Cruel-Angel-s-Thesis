using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderdeSonido : MonoBehaviour
{
    public Slider slider;
    public float sliderValor;


    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
    }

    public void CambiarSlider(float valor)
    {
        sliderValor = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValor);
        AudioListener.volume = slider.value;
        PlayerPrefs.Save();
    }
}
