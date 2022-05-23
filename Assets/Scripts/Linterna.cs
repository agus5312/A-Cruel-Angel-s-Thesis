using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Linterna : MonoBehaviour
{
    public GameObject luz;
    bool encendida;
    public GameObject maracador;
    public Slider slider;
    float bateria = 1;
    

    private void Start()
    {
        maracador.SetActive(true);
        luz.SetActive(false);
        encendida = false;
        slider.value = bateria;
    }
    void Update()
    {
        if (encendida == true)
        {
            bateria -= 0.01f * Time.deltaTime;
            if(bateria < 0)
            {
                encendida = false;
                luz.SetActive(false);
                
            }

            slider.value = bateria;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (encendida == true)
            {
                luz.SetActive(false);
                encendida = false;
                
            }
            else if (bateria > 0)
            {
                luz.SetActive(true);
                encendida = true;

            }
        }

        
    }

    private void OnEnable()
    {
        maracador.SetActive(true);
    }

    private void OnDisable()
    {
        maracador.SetActive(false);
    }
}
