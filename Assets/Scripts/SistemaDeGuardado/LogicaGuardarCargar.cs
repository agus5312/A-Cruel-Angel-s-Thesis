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
    [SerializeField] GameObject eventoFroggers;
    [SerializeField] GameObject eventocabaña;
    [SerializeField] GameObject sombras;
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
            //linterna.pilas = informacionGuardar.pilas;
            camara.tiros = informacionGuardar.tiros;
            //linterna.bateria = informacionGuardar.batRestante;
        }


        if (informacionGuardar.froggers)
        {
            froggers.SetActive(true);
            eventoFroggers.SetActive(false);
        }
        if (informacionGuardar.eventocabaña)
        {
            eventoFroggers.SetActive(false);
        }
        if (informacionGuardar.sombras)
        {
            eventoFroggers.SetActive(false);
        }
        if (informacionGuardar.linterna)
        {
            cambiaItems.objetos.Add(cambiaItems.linterna);
        }
        if (informacionGuardar.camara)
        {
            cambiaItems.objetos.Add(cambiaItems.camara);
        }
        foreach (TipoLllave llave in informacionGuardar.llaves)
        {
            cambiaItems.llaves.Add(llave);
        }

        foreach (int objeto in informacionGuardar.aDesactivar)
        {
            if(objetos[objeto])
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
        informacionGuardar.posplayer = new Vector3(190, 0.4f, -370);

        //informacionGuardar.pilas = 0;
        informacionGuardar.tiros = 4;
        //informacionGuardar.batRestante = 1;

        informacionGuardar.froggers = false;

        informacionGuardar.linterna = false;
        informacionGuardar.camara = false;

        informacionGuardar.aDesactivar.Clear();
        informacionGuardar.llaves.Clear();

        GuardarPartida(informacionGuardar);
    }

    public void GuardarInformacion()
    {
            if (player)
            {
                informacionGuardar.posplayer = player.transform.position;
                //informacionGuardar.pilas = linterna.pilas;
                informacionGuardar.tiros = camara.tiros;
                //informacionGuardar.batRestante = linterna.bateria;
            }
            else Debug.LogWarning("Falta Player");

            GuardarPartida(informacionGuardar);
    }

    public void GuardarInformacionCambioEscena(Vector3 pos)
    {
        if (player)
        {
            informacionGuardar.posplayer = pos;
            //informacionGuardar.pilas = linterna.pilas;
            informacionGuardar.tiros = camara.tiros;
            //informacionGuardar.batRestante = linterna.bateria;
        }
        else Debug.LogWarning("Falta Player");

        GuardarPartida(informacionGuardar);
    }
    public void CargarInformacion()
    {
        CargarPartida(informacionGuardar);
    }
}
