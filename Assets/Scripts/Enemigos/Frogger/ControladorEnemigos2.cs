using System.Collections;
<<<<<<< Updated upstream
using System.Collections.Generic;
=======
>>>>>>> Stashed changes
using UnityEngine;

public class ControladorEnemigos2 : MonoBehaviour
{
    [SerializeField] GameObject frogger;

    public void IniciarAtaque(Vector3 pos)
    {
        frogger.transform.position = pos;
        frogger.SetActive(true);
    }

    public void DetenerAtaque(Vector3 pos)
    {
        frogger.GetComponent<Frogger3>().Deshabilitar(pos);
        StartCoroutine("Desactivar");
    }


    IEnumerator Desactivar()
    {
        yield return new WaitForSeconds(15f);
        frogger.SetActive(false);
    }

}
