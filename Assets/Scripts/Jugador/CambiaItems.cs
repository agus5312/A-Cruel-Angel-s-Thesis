using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaItems : MonoBehaviour
{
    [SerializeField] GameObject menuPausa;
    bool pausa;
    bool moviendose;
    public List<GameObject> objetos;
    int i;
    public GameObject linterna;
    public GameObject camara;
    public List<string> llaves;

    InformacionGuardar informacionGuardar;
    LogicaGuardarCargar logica;
    StarterAssets.FirstPersonController controlador;
    StarterAssets.StarterAssetsInputs imputs;

    AudioSource pasos;
    [SerializeField] AudioClip caminar;
    [SerializeField] AudioClip correr;

    private void Start()
    {
        informacionGuardar = FindObjectOfType<InformacionGuardar>();
        logica = FindObjectOfType<LogicaGuardarCargar>();
        controlador = FindObjectOfType<StarterAssets.FirstPersonController>();
        imputs = FindObjectOfType<StarterAssets.StarterAssetsInputs>();
        pasos = GetComponent<AudioSource>();

        pausa = false;
        i = 0;
        for (int a = 0; a < objetos.Count; a++)
        {
            objetos[a].SetActive(false);
        }
    }
    void Update()
    {
        Pasos();
        Items();
        Menu();
    }

    void Items()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            objetos[i].SetActive(false);
            i--;
            if (i < 0)
            {
                i = objetos.Count - 1;
            }
            objetos[i].SetActive(true);
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            objetos[i].SetActive(false);
            i++;
            if (i > objetos.Count - 1)
            {
                i = 0;
            }
            objetos[i].SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                ObjetoEnSuelo tag = hitInfo.collider.GetComponent<ObjetoEnSuelo>();
                if (tag)
                {
                    switch (tag.type)
                    {
                        case "Bateria":
                            linterna.GetComponent<Linterna>().MasPilas();
                            //informacionGuardar.aDesactivar.Add(hitInfo.collider.gameObject);
                            foreach (GameObject item in logica.objetos)
                            {
                                if (hitInfo.collider.gameObject == item)
                                {
                                    informacionGuardar.aDesactivar.Add(logica.objetos.IndexOf(item));
                                    break;
                                }
                            }
                            hitInfo.collider.gameObject.SetActive(false);
                            break;

                        case "Rollo":
                            camara.GetComponent<Flash>().AumentarTiros();
                            //informacionGuardar.aDesactivar.Add(hitInfo.collider.gameObject);
                            foreach (GameObject item in logica.objetos)
                            {
                                if (hitInfo.collider.gameObject == item)
                                {
                                    informacionGuardar.aDesactivar.Add(logica.objetos.IndexOf(item));
                                    break;
                                }
                            }
                            hitInfo.collider.gameObject.SetActive(false);
                            break;

                        case "Puerta":
                            GameObject puerta = hitInfo.collider.gameObject;
                            for (int i = 0; i < llaves.Count; i++)
                            {
                                if (llaves[i] == puerta.GetComponent<Puertas>().tipo)
                                {
                                    puerta.GetComponent<Puertas>().AbrirPuerta();
                                }
                            }
                            break;

                        case "Llave":
                            llaves.Add(hitInfo.collider.gameObject.GetComponent<Llave>().type);
                            informacionGuardar.llaves.Add(hitInfo.collider.gameObject.GetComponent<Llave>().type);
                            //informacionGuardar.aDesactivar.Add(hitInfo.collider.gameObject);
                            foreach (GameObject item in logica.objetos)
                            {
                                if (hitInfo.collider.gameObject == item)
                                {
                                    informacionGuardar.aDesactivar.Add(logica.objetos.IndexOf(item));
                                    break;
                                }
                            }
                            hitInfo.collider.gameObject.SetActive(false);
                            break;

                        case "Linterna":
                            objetos.Add(linterna);
                            informacionGuardar.linterna = true;
                            //informacionGuardar.aDesactivar.Add(hitInfo.collider.gameObject);
                            foreach (GameObject item in logica.objetos)
                            {
                                if (hitInfo.collider.gameObject == item)
                                {
                                    informacionGuardar.aDesactivar.Add(logica.objetos.IndexOf(item));
                                    break;
                                }
                            }
                            hitInfo.collider.gameObject.SetActive(false);
                            break;

                        case "Camara":
                            objetos.Add(camara);
                            informacionGuardar.camara = true;
                            //informacionGuardar.aDesactivar.Add(hitInfo.collider.gameObject);
                            foreach (GameObject item in logica.objetos)
                            {
                                if (hitInfo.collider.gameObject == item)
                                {
                                    informacionGuardar.aDesactivar.Add(logica.objetos.IndexOf(item));
                                    break;
                                }
                            }
                            hitInfo.collider.gameObject.SetActive(false);
                            break;

                        default:

                            break;
                    }

                }

            }
        }
    }

    void Pasos()
    {
        if (imputs.move != new Vector2(0, 0) && controlador.Grounded)
        {
            if(moviendose == false)
            {
                pasos.Play();
            }
            moviendose = true;
        }
        else
        {
            pasos.Stop();
            moviendose = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            pasos.clip = correr;
            pasos.Play();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            pasos.clip = caminar;
            pasos.Play();
        }
    }

    void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (pausa)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
                menuPausa.SetActive(false);
                pausa = false;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                menuPausa.SetActive(true);
                pausa = true;
            }
        }
    }

}
