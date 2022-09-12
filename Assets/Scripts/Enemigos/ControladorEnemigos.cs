using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemigos : MonoBehaviour
{
    [SerializeField] GameObject enemigo;
    [SerializeField] List<Vector3> pos;
    CambiaItems player;
    [SerializeField] float time;
    

    void Start()
    {
        StartCoroutine(Ataque());
        player = FindObjectOfType<CambiaItems>();
    }

    IEnumerator Ataque()
    {
        yield return new WaitForSeconds(time);
        

        if (pos.Count > 0)
            {
                float cerca = 0;
                float ant = 0;
                int ind = 0;
                for (int i = 0; i < pos.Count; i++)
                {
                    cerca = Vector3.Distance(player.gameObject.transform.position, pos[i]);
                    if (ant == 0)
                    {
                        ant = cerca;
                    }
                    if (cerca < ant)
                    {
                        ind = i;
                    }
                }
            if (!enemigo.activeInHierarchy)
            {
                enemigo.transform.position = pos[ind];
                enemigo.SetActive(true);
            }
        }
        StartCoroutine(Ataque());
    }
}
