using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    Light LMoon;
    Renderer rend;
    float a = 1;
    //[SerializeField] int velocity;
    void Start()
    {
        LMoon = GetComponent<Light>();
        rend = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        //transform.Rotate(velocity * Time.deltaTime, 0, 0);
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(Cambiar());
            
        }
    }

    public void Bajar()
    {
        LMoon.intensity = 0.03f;
    }

    public void Subir()
    {
        LMoon.intensity = 0.07f;
    }


    IEnumerator Cambiar()
    {

        for (int i = 0; i < 100; i++)
        {
            a -= 0.01f;
            rend.material.SetColor("_EmissionColor", new Color(1, a, a));
            LMoon.color = new Color(1, a, a);
            LMoon.intensity += 0.0018f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    
}
