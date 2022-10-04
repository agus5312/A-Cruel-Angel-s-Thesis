using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaGuardarMenu : MonoBehaviour
{
    InformacionGuardar informacionGuardar;

    private void Start()
    {
        informacionGuardar = FindObjectOfType<InformacionGuardar>();
        CargarInformacion();
    }

    public void CargarInformacion()
    {
        CargarPartida(informacionGuardar);
    }

    public static void CargarPartida(MonoBehaviour informacion)
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("infoPartida"), informacion);
    }

}
