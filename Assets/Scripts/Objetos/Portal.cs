using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public TipoLllave tipo;
    [SerializeField] Vector3 puntoAparicion;
    LogicaGuardarCargar logica;
    [SerializeField] string scene;

    private void Start()
    {
        logica = FindObjectOfType<LogicaGuardarCargar>();
    }
    public void Cambio()
    {
        logica.GuardarInformacionCambioEscena(puntoAparicion, scene);
        SceneManager.LoadScene(scene);
    }
}
