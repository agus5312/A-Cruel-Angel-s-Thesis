using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAngeles : MonoBehaviour
{
    [SerializeField] Angeles[] grupo1;
    [SerializeField] Angeles[] grupo2;
    [SerializeField] Angeles[] grupo3;
    [SerializeField] Angeles[] grupo4;
    [SerializeField] Angeles[] grupo5;
    [SerializeField] Angeles[] grupo6;

    public void Activar(int a)
    {
        switch (a)
        {
            case 1:
                for (int i = 0; i < grupo1.Length; i++)
                {
                    grupo1[i].enabled = true;
                }
                break;
            case 2:
                for (int i = 0; i < grupo2.Length; i++)
                {
                    grupo2[i].enabled = true;
                }
                break;
            case 3:
                for (int i = 0; i < grupo3.Length; i++)
                {
                    grupo3[i].enabled = true;
                }
                break;
            case 4:
                for (int i = 0; i < grupo4.Length; i++)
                {
                    grupo4[i].enabled = true;
                }
                break;
            case 5:
                for (int i = 0; i < grupo5.Length; i++)
                {
                    grupo5[i].enabled = true;
                }
                break;
            case 6:
                for (int i = 0; i < grupo6.Length; i++)
                {
                    grupo6[i].enabled = true;
                }
                break;
        }
    }

    public void Desactivar(int a)
    {
        switch (a)
        {
            case 1:
                for (int i = 0; i < grupo1.Length; i++)
                {
                    grupo1[i].enabled = false;
                }
                for (int i = 0; i < grupo2.Length; i++)
                {
                    grupo2[i].enabled = false;
                }
                for (int i = 0; i < grupo3.Length; i++)
                {
                    grupo3[i].enabled = false;
                }
                for (int i = 0; i < grupo4.Length; i++)
                {
                    grupo4[i].enabled = false;
                }
                break;
            case 2:
                for (int i = 0; i < grupo5.Length; i++)
                {
                    grupo5[i].enabled = false;
                }
                break;
            case 3:
                for (int i = 0; i < grupo6.Length; i++)
                {
                    grupo6[i].enabled = false;
                }
                break;
        }
    }

}
