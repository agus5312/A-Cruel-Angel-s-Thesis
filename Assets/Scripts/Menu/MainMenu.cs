using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject luzLinterna;
    [SerializeField] GameObject main;
    [SerializeField] GameObject panel;
    private void Start()
    {
        luzLinterna = GameObject.FindGameObjectWithTag("Luz");
        luzLinterna.SetActive(false);
        StartCoroutine(PrenderLinterna(Random.Range(0.1f, 1)));
        main.SetActive(true);
        panel.SetActive(false);
    }

    IEnumerator PrenderLinterna(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        luzLinterna.SetActive(true);
        StartCoroutine(ApagarLinterna(Random.Range(0.1f,1)));
    }

    IEnumerator ApagarLinterna(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        luzLinterna.SetActive(false);
        StartCoroutine(PrenderLinterna(Random.Range(0.5f, 1.5f)));
    }

    public void Play()
    {
        SceneManager.LoadScene("Playground");
    }

    public void Options()
    {
        main.SetActive(false);
        panel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void QuitMenu()
    {
        main.SetActive(true);
        panel.SetActive(false);
    }
}
