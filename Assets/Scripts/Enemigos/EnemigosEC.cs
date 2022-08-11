using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigosEC : MonoBehaviour
{

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(Tiempo());
    }

    IEnumerator Tiempo()
    {
        yield return new WaitForSeconds(6f);
        print("Perdiste");
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flash"))
        {
            StopCoroutine(Tiempo());
            gameObject.SetActive(false);
        }
    }
}
