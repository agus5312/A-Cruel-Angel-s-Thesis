using UnityEngine.Playables;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CamaraDeMuerte : MonoBehaviour
{
    [SerializeField]GameObject camaraPrincpal;
    [SerializeField] GameObject camara;
    [SerializeField] GameObject bicho;
    [SerializeField]GameObject[] desactivados;
    PlayableDirector director;

    private void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    public void Muerte()
    {
        transform.position = camaraPrincpal.transform.position;
        for (int i = 0; i < desactivados.Length; i++)
        {
            desactivados[i].SetActive(false);
        }
        camara.SetActive(true);
        director.Play();
        StartCoroutine(resetear());
    }

    private IEnumerator resetear()
    {
        yield return new WaitForSeconds(1.5f);
        bicho.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene("Playground");
    }
}
