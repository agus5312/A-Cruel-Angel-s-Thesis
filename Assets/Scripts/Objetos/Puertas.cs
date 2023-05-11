using UnityEngine;

public class Puertas : MonoBehaviour
{
    public TipoLllave tipo;
    public string texto;
    Animator anim;
    [SerializeField] AudioClip abrir;
    [SerializeField] AudioClip cerrar;
    AudioSource sonid;
    bool cerrada;
    private void Start()
    {
        anim = GetComponent<Animator>();
        sonid = GetComponent<AudioSource>();
        cerrada = true;
    }
    public void AbrirPuerta()
    {
        anim.SetTrigger("Cambio");
        if (cerrada)
        {
            sonid.clip = abrir;
            sonid.Play();
            cerrada = false;
        }
        else
        {
            sonid.clip = cerrar;
            sonid.Play();
            cerrada = true;
        }
    }

}
