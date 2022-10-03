using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuerteSombras : MonoBehaviour
{
    [SerializeField] GameObject[] activar;
    [SerializeField] GameObject oscuro;
    [SerializeField] GameObject[] desactivados;
    AudioSource audi;
    public void Muerte()
    {
        audi = GetComponent<AudioSource>();
        oscuro.SetActive(true);
        for (int i = 0; i < desactivados.Length; i++)
        {
            desactivados[i].SetActive(false);
        }
        for (int i = 0; i < activar.Length; i++)
        {
            activar[i].SetActive(true);
        }
        StartCoroutine(resetear());
    }

    private IEnumerator resetear()
    {
        yield return new WaitForSeconds(1);
        oscuro.SetActive(false);
        yield return new WaitForSeconds(5.5f);
        oscuro.SetActive(true);
        yield return new WaitForSeconds(1);
        audi.Play();
        oscuro.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Playground");
    }
}
