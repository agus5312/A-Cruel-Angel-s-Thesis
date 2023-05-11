using UnityEngine;

public class LogicaGuardarMenu : MonoBehaviour
{
    InformacionGuardar informacionGuardar;

    private void Start()
    {
        informacionGuardar = FindObjectOfType<InformacionGuardar>();
        CargarInformacion();
    }

    public static void GuardarPartida(MonoBehaviour informacion)
    {
        PlayerPrefs.SetString("infoPartida", JsonUtility.ToJson(informacion));
    }

    public void LimpiarInformacion()
    {
        informacionGuardar.posplayer = new Vector3(190, 0.4f, -370);

        informacionGuardar.tiros = 4;

        informacionGuardar.froggers = false;
        informacionGuardar.sombras = false;
        informacionGuardar.eventocabaña = false;
        informacionGuardar.cinematicaInicial = false;

        informacionGuardar.linterna = false;
        informacionGuardar.camara = false;

        informacionGuardar.escena = "Playground";

        informacionGuardar.aDesactivar.Clear();
        informacionGuardar.llaves.Clear();
        informacionGuardar.checkpoints.Clear();

        GuardarPartida(informacionGuardar);
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
