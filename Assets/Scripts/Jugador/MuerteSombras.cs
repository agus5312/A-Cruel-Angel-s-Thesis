using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MuerteSombras : MonoBehaviour
{
    [SerializeField] GameObject[] activar;
    [SerializeField] GameObject oscuro;
    [SerializeField] GameObject[] desactivados;
    AudioSource audi;
    [SerializeField] AudioClip voz;
    [SerializeField] AudioClip cuello;
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
        oscuro.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        yield return new WaitForSeconds(1);
        oscuro.SetActive(false);
        yield return new WaitForSeconds(5.5f);
        oscuro.SetActive(true);
        yield return new WaitForSeconds(1);
        audi.clip = voz;
        audi.Play();
        oscuro.SetActive(true);
        yield return new WaitForSeconds(1);
        audi.clip = cuello;
        audi.Play();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Playground");
    }
}
