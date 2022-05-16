using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaItems : MonoBehaviour
{
    public GameObject[] objetos;
    int i;

    private void Start()
    {
        i = 0;
        for (int a = 0; a < objetos.Length; a++)
        {
            objetos[a].SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            objetos[i].SetActive(false);
            i--;
            if (i < 0)
            {
                i = objetos.Length -1;
            }
            objetos[i].SetActive(true);
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            objetos[i].SetActive(false);
            i++;
            if(i > objetos.Length -1)
            {
                i = 0;
            }
            objetos[i].SetActive(true);
        }
    }

}
