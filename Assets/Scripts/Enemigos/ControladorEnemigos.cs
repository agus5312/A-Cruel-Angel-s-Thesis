using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemigos : MonoBehaviour
{
    [SerializeField] GameObject enemigo;
    [SerializeField] List<Vector3> pos;
    CambiaItems player;
    [SerializeField] float time;
    bool firsttime = true;

    private void OnEnable()
    {
        StartCoroutine(Ataque());
    }
    void Start()
    {
        StartCoroutine(Ataque());
        player = FindObjectOfType<CambiaItems>();
    }
    
    

    IEnumerator Ataque()
    {
        if (firsttime)
        {
            yield return new WaitForSeconds(25);
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
                        ant = cerca;
                    }
                }
                if (!enemigo.activeInHierarchy)
                {
                    enemigo.transform.position = pos[ind];
                    enemigo.SetActive(true);
                }
            }
            firsttime = false;
        }


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
