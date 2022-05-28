using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaItems : MonoBehaviour
{

    public List<GameObject> objetos;
    int i;
    public GameObject linterna;
    public GameObject camara;
    private void Start()
    {
        
        i = 0;
        for (int a = 0; a < objetos.Count; a++)
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
                i = objetos.Count -1;
            }
            objetos[i].SetActive(true);
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            objetos[i].SetActive(false);
            i++;
            if(i > objetos.Count -1)
            {
                i = 0;
            }
            objetos[i].SetActive(true);
        }

        

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                string Tag = hitInfo.collider.gameObject.tag;
                switch (Tag)
                {
                    case "Linterna":
                        objetos.Add(linterna);
                        Destroy(hitInfo.collider.gameObject);
                        break;

                    case "Camara":
                        objetos.Add(camara);
                        Destroy(hitInfo.collider.gameObject);
                        break;

                    case "Bateria":
                        linterna.GetComponent<Linterna>().AumentarBateria();
                        Destroy(hitInfo.collider.gameObject);
                        break;
                    case "Rollo":
                        camara.GetComponent<Flash>().AumentarTiros();
                        Destroy(hitInfo.collider.gameObject);
                        break;

                    default:
                        
                        break;
                }
            }
        }
    }


}
