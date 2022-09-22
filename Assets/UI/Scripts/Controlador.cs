using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    [SerializeField] GameObject PanelOpciones;
    [SerializeField] GameObject estaSeguro;
    public void Opciones()
    {
        PanelOpciones.SetActive(true);
    }
    public void VolverdeOpcionesaMenu()
    {
        PanelOpciones.SetActive(false);
    }

    public void InGame(string name)
    {
        SceneManager.LoadScene(name);
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
}