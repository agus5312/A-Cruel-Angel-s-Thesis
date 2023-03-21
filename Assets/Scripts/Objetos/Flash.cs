using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    public GameObject flash;
    public GameObject texto;
    public int tiros = 4;
    public Text cantidad;
    AudioSource audi;
    void Start()
    {
        flash.SetActive(false);
        cantidad.text = tiros.ToString();
        audi = GetComponent<AudioSource>();
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
        audi.Play();
        yield return new WaitForSeconds(0.1f);
        flash.SetActive(false); 
    }

    public void AumentarTiros()
    {
        tiros += 40;
        cantidad.text = tiros.ToString();
    }
    private void OnDisable()
    {
        if(texto)
            texto.SetActive(false);
    }
}
