using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    public GameObject flash;
    public GameObject texto;
    int tiros = 4;
    public Text cantidad;
    void Start()
    {
        flash.SetActive(false);
        cantidad.text = tiros.ToString();
    }

    private void OnEnable()
    {
        texto.SetActive(true);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && tiros > 0)
        {
            StartCoroutine(tiempo());
            tiros--;
            cantidad.text = tiros.ToString();
        }
    }

    IEnumerator tiempo()
    {
        flash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        flash.SetActive(false); 
    }

    private void OnDisable()
    {
        texto.SetActive(false);
    }
}
