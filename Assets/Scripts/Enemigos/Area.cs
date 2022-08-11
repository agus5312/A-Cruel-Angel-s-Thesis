using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    ControladorEnemigos ce;
    private void Start()
    {
        ce = FindObjectOfType<ControladorEnemigos>();
    }
    private void OnTriggerEnter(Collider other)
    {

        CambiaItems player = other.GetComponent<CambiaItems>();

        if (player)
        {
            if(ce.Enemigos.Count > 0)
            {
                float cerca = 0;
                float ant = 0;
                int ind = 0;
                for (int i = 0; i < ce.Enemigos.Count; i++)
                {
                    cerca = Vector3.Distance(player.gameObject.transform.position, ce.Enemigos[i].transform.position);
                    if (ant == 0)
                    {
                        ant = cerca;
                    }
                    if(cerca < ant)
                    {
                        ind = i;
                    }
                }
                ce.Enemigos[ind].SetActive(true);
                print(ind);
            }
        }

    }
}
