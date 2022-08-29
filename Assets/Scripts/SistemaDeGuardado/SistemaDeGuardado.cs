using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDeGuardado : MonoBehaviour
{
    [SerializeField] GameObject froggers;
    [SerializeField] GameObject angeles;

    [SerializeField] Linterna linterna;
    [SerializeField] Flash camara;
    GameObject player;
    CambiaItems cambiaItems;

    public int froggersActivos;
    public int angelesActivos;
    public int tengoLinterna;
    public int tengoCamara;
    public string llaveIglesia;
    public string llaveCabaña;


    private void Start()
    {
        player = FindObjectOfType<CambiaItems>().gameObject;
        cambiaItems = FindObjectOfType<CambiaItems>();


        player.transform.position = new Vector3(PlayerPrefs.GetFloat("posx"), PlayerPrefs.GetFloat("posy"), PlayerPrefs.GetFloat("posz"));
        linterna.pilas = PlayerPrefs.GetInt("Baterias");
        camara.tiros = PlayerPrefs.GetInt("TCamara");
        linterna.bateria = PlayerPrefs.GetFloat("BateriaRestante");

        if(PlayerPrefs.GetInt("Froggers") == 1)
        {
            froggers.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Angeles") == 1)
        {
            angeles.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Linterna") == 1)
        {
            cambiaItems.objetos.Add(cambiaItems.linterna);
        }
        if (PlayerPrefs.GetInt("Camara") == 1)
        {
            cambiaItems.objetos.Add(cambiaItems.camara);
        }
        if (PlayerPrefs.GetString("LlaveIglesia") == "Iglesia")
        {
            cambiaItems.llaves.Add("Iglesia");
        }
        if (PlayerPrefs.GetString("LlaveCabaña") == "Cabaña")
        {
            cambiaItems.llaves.Add("Cabaña");
        }

    }
    public void save()
    {
        PlayerPrefs.SetInt("Baterias", linterna.pilas);
        PlayerPrefs.SetInt("TCamara", camara.tiros);
        PlayerPrefs.SetFloat("BateriaRestante",linterna.bateria);

        PlayerPrefs.SetFloat("posx", player.transform.position.x);
        PlayerPrefs.SetFloat("posy", player.transform.position.y);
        PlayerPrefs.SetFloat("posz", player.transform.position.z);

        PlayerPrefs.SetInt("Froggers",froggersActivos);
        PlayerPrefs.SetInt("Angeles",angelesActivos);

        PlayerPrefs.SetInt("Linterna", tengoLinterna);
        PlayerPrefs.SetInt("Camara", tengoCamara);
        PlayerPrefs.SetString("LlaveIglesia", llaveIglesia);
        PlayerPrefs.SetString("LlaveCabaña", llaveCabaña);

        PlayerPrefs.Save();
    }
}
