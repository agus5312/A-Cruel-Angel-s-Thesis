using UnityEngine;

public class CambiaSonidos : MonoBehaviour
{
    [SerializeField] AudioClip pasosBosque;
    [SerializeField] AudioClip pasosCaba�a;
    [SerializeField] AudioClip pasosIglesia;

    [SerializeField] AudioClip correrBosque;
    [SerializeField] AudioClip correrCaba�a;
    [SerializeField] AudioClip correrIglesia;

    [SerializeField] AudioClip ambienteBosque;
    [SerializeField] AudioClip ambienteCaba�a;
    [SerializeField] AudioClip ambienteIglesia;

    [SerializeField] Lugar lugar;

    [SerializeField] AudioSource ambiente;
    [SerializeField] AudioSource pasosPersonaje;

    private void OnTriggerEnter(Collider other)
    {
        CambiaItems player = other.GetComponent<CambiaItems>();
        if (player)
        {
            CambiaItems items = player.GetComponent<CambiaItems>();
            switch (lugar)
            {
                case Lugar.BOSQUE:
                    items.caminar = pasosBosque;
                    items.correr = correrBosque;
                    pasosPersonaje.clip = pasosBosque;
                    pasosPersonaje.Play();
                    ambiente.clip = ambienteBosque;
                    ambiente.Play();
                    break;

                case Lugar.IGLESIA:
                    items.caminar = pasosIglesia;
                    items.correr = correrIglesia;
                    pasosPersonaje.clip = pasosIglesia;
                    pasosPersonaje.Play();
                    ambiente.clip = ambienteIglesia;
                    ambiente.Play();
                    break;

                case Lugar.CABA�A:
                    items.caminar = pasosCaba�a;
                    items.correr = correrCaba�a;
                    pasosPersonaje.clip = pasosCaba�a;
                    pasosPersonaje.Play();
                    ambiente.clip = ambienteCaba�a;
                    ambiente.Play();
                    break;

                default:
                    break;

            }

        }
    }
}
