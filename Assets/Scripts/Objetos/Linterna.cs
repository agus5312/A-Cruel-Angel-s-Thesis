using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Linterna : MonoBehaviour
{
    public GameObject luz;
    bool encendida;
    public GameObject maracador;
    public GameObject contador;
    public Slider slider;
    public Text cantidadpilas;
    public float bateria = 1;
    public int pilas = 0;
    

    private void Start()
    {
        maracador.SetActive(true);
        contador.SetActive(true);
        luz.SetActive(false);
        encendida = false;
        slider.value = bateria;
        cantidadpilas.text = pilas.ToString();
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

        if (Input.GetKey(KeyCode.R) && pilas > 0)
        {
            AumentarBateria();
            pilas--;
            cantidadpilas.text = pilas.ToString();
        }
    }

    public void MasPilas()
    {
        pilas++;
        cantidadpilas.text = pilas.ToString();
    }

    public void AumentarBateria()
    {
        bateria = 1;
        slider.value = bateria;
    }
    private void OnEnable()
    {
        maracador.SetActive(true);
        contador.SetActive(true);
    }

    private void OnDisable()
    {
        if (maracador)
        {
            maracador.SetActive(false);
            contador.SetActive(false);
        }
    }
}
