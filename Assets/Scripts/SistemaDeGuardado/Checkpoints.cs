
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    LogicaGuardarCargar logica;
    InformacionGuardar informacion;
    [SerializeField]Vector3 pos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CambiaItems>())
        {
            logica = FindObjectOfType<LogicaGuardarCargar>();
            informacion = FindObjectOfType<InformacionGuardar>();
            foreach (GameObject check in logica.checkpoints)
            {
                if (gameObject == check)
                {
                    informacion.checkpoints.Add(logica.checkpoints.IndexOf(check));
                    break;
                }
            }
            logica.GuardarInformacion(pos);
            gameObject.SetActive(false);
        }
    }
}
