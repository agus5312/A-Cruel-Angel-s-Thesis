using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaGuardarCargar : MonoBehaviour
{
    InformacionGuardar informacionGuardar;
    GameObject player;
    CambiaItems cambiaItems;
    [SerializeField] Flash camara;
    [SerializeField] Linterna linterna;

    [SerializeField] GameObject froggers;
    [SerializeField] GameObject angeles;

    public List<GameObject> objetos;

    private void Start()
    {
        informacionGuardar = FindObjectOfType<InformacionGuardar>();
        CargarInformacion();

        player = FindObjectOfType<CambiaItems>().gameObject;
        cambiaItems = FindObjectOfType<CambiaItems>();

        if (player)
        {
            player.transform.position = informacionGuardar.posplayer;
            linterna.pilas = informacionGuardar.pilas;
            camara.tiros = informacionGuardar.tiros;
            linterna.bateria = informacionGuardar.batRestante;
        }


        if (informacionGuardar.froggers)
        {
            froggers.SetActive(true);
        }
        if (informacionGuardar.angeles)
        {
            angeles.SetActive(true);
        }
        if (informacionGuardar.linterna)
        {
            cambiaItems.objetos.Add(cambiaItems.linterna);
        }
        if (informacionGuardar.camara)
        {
            cambiaItems.objetos.Add(cambiaItems.camara);
        }
        foreach (string llave in informacionGuardar.llaves)
        {
            cambiaItems.llaves.Add(llave);
        }
        //foreach (GameObject objeto in informacionGuardar.aDesactivar)
        //{
        //    objeto.SetActive(false);
        //}
        foreach (int objeto in informacionGuardar.aDesactivar)
        {
            objetos[objeto].SetActive(false);
        }
    }

    public static void GuardarPartida(MonoBehaviour informacion)
    {
        PlayerPrefs.SetString("infoPartida", JsonUtility.ToJson(informacion));
    }
    public static void CargarPartida(MonoBehaviour informacion)
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("infoPartida"), informacion);
    }

    public void LimpiarInformacion()
    {
        informacionGuardar.posplayer = new Vector3(0, 0, 0);

        informacionGuardar.pilas = 0;
        informacionGuardar.tiros = 4;
        informacionGuardar.batRestante = 1;

        informacionGuardar.froggers = false;
        informacionGuardar.angeles = false;

        informacionGuardar.linterna = false;
        informacionGuardar.camara = false;

        informacionGuardar.aDesactivar.Clear();
        informacionGuardar.llaves.Clear();

        GuardarPartida(informacionGuardar);
    }

    public void GuardarInformacion()
    {
        informacionGuardar.posplayer = player.transform.position;

        informacionGuardar.pilas = linterna.pilas;
        informacionGuardar.tiros = camara.tiros;
        informacionGuardar.batRestante = linterna.bateria;

        GuardarPartida(informacionGuardar);
    }
    public void CargarInformacion()
    {
        CargarPartida(informacionGuardar);
    }
}