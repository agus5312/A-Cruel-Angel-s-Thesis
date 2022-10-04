using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    [SerializeField] GameObject PanelOpciones;
    [SerializeField] GameObject estaSeguro;
    [SerializeField] GameObject Sound;
    [SerializeField] GameObject Brillo;
    [SerializeField] GameObject SoundButton;
    [SerializeField] GameObject BrilloButton;
    [SerializeField] GameObject BackButton;
    [SerializeField] GameObject BackSliderB;

    InformacionGuardar informacion;

    public void Opciones()
    {
        PanelOpciones.SetActive(true);
    }
    public void VolverdeOpcionesaMenu()
    {
        PanelOpciones.SetActive(false);
    }

    public void InGame()
    {
        informacion = FindObjectOfType<InformacionGuardar>();
        if(informacion.escena == "Pruebas")
        {
            SceneManager.LoadScene("Pruebas");
        }
        else
        {
            SceneManager.LoadScene("Playground");
        }
    }
    public void panel()
    {
        estaSeguro.SetActive(true);
    }
    public void salirno()
    {
        estaSeguro.SetActive(false);
    }
    public void salirsi()
    {
        Debug.Log("Se salio del juego");
        Application.Quit();
    }
    public void AparecerSliderSound()
    {
        Sound.SetActive(true);
        SoundButton.SetActive(false);
        BrilloButton.SetActive(false);
        BackButton.SetActive(false);
        BackSliderB.SetActive(true);
    }
    public void DesaparecerSliderSound ()
    {
        Sound.SetActive(false);
        SoundButton.SetActive(true);
        BrilloButton.SetActive(true);
        BackButton.SetActive(true);
        BackSliderB.SetActive(false);
    }
    public void AparecerSliderBrillo()
    {
        Brillo.SetActive(true);
        SoundButton.SetActive(false);
        BrilloButton.SetActive(false);
        BackButton.SetActive(false);
        BackSliderB.SetActive(true);
    }
    public void DesaparecerSliderBrillo()
    {
        Brillo.SetActive(false);
        SoundButton.SetActive(true);
        BrilloButton.SetActive(true);
        BackButton.SetActive(true);
        BackSliderB.SetActive(false);
    }
}