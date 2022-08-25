using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemigos : MonoBehaviour
{
    [SerializeField] List<GameObject> enemigos;
    /// <summary>
    /// Lista de enemigos
    /// </summary>
    public List<GameObject> Enemigos 
        {
         get{return enemigos;}
        }

    void Start()
    {
        StartCoroutine(Ataque());
    }

    IEnumerator Ataque()
    {
        CambiaItems player = FindObjectOfType<CambiaItems>();
        if (player)
        {
            yield return new WaitForSeconds(90);
            if (Enemigos.Count > 0)
            {
                float cerca = 0;
                float ant = 0;
                int ind = 0;
                for (int i = 0; i < Enemigos.Count; i++)
                {
                    cerca = Vector3.Distance(player.gameObject.transform.position, Enemigos[i].transform.position);
                    if (ant == 0)
                    {
                        ant = cerca;
                    }
                    if (cerca < ant)
                    {
                        ind = i;
                    }
                }
                Enemigos[ind].SetActive(true);
            }
        }
        StartCoroutine(Ataque());
    }
}
