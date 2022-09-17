using UnityEngine;

public class CambiaSonidos : MonoBehaviour
{
    [SerializeField] AudioClip pasosBosque;
    [SerializeField] AudioClip pasosCabaña;
    [SerializeField] AudioClip pasosIglesia;

    [SerializeField] AudioClip correrBosque;
    [SerializeField] AudioClip correrCabaña;
    [SerializeField] AudioClip correrIglesia;

    [SerializeField] AudioClip ambienteBosque;
    [SerializeField] AudioClip ambienteCabaña;
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

                case Lugar.CABAÑA:
                    items.caminar = pasosCabaña;
                    items.correr = correrCabaña;
                    pasosPersonaje.clip = pasosCabaña;
                    pasosPersonaje.Play();
                    ambiente.clip = ambienteCabaña;
                    ambiente.Play();
                    break;

                default:
                    break;

            }

        }
    }
}
