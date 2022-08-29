using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoCabaña : MonoBehaviour
{
    public GameObject[] enemigos;
    int oleada = 0;
    [SerializeField] Moon moon;

    public void Oleada()
    {
        if(oleada == 0)
        {
            moon.Bajar();
        }
        oleada++;
        if (oleada < 5)
        {
            enemigos[Random.Range(0, 4)].SetActive(true);
            StartCoroutine(Time());
        }
        else if (oleada < 10)
        {
            enemigos[Random.Range(0, 2)].SetActive(true);
            enemigos[Random.Range(2, 4)].SetActive(true);
            StartCoroutine(Time());
        }
        else if (oleada < 15)
        {
            enemigos[Random.Range(0, 2)].SetActive(true);
            enemigos[Random.Range(2, 4)].SetActive(true);
            enemigos[Random.Range(1, 3)].SetActive(true);
            StartCoroutine(Time());
        }
        else if (oleada == 15)
        {
            enemigos[0].SetActive(true);
            enemigos[1].SetActive(true);
            enemigos[2].SetActive(true);
            enemigos[3].SetActive(true);
            StartCoroutine(Time());
        }
        else
        {
            Fin();
        }
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(6.5f);
        Oleada();
    }

    void Fin()
    {
        print("FinEvento");
        moon.Subir();
    }


}
