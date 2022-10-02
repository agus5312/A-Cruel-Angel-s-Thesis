using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class FinDelJuego : MonoBehaviour
{
    [SerializeField] PlayableDirector direc;
    [SerializeField] GameObject[] descativar;
    [SerializeField] AudioSource terrein;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CambiaItems>())
        {
            terrein.Stop();
            StartCoroutine(Fin()); 
            for (int i = 0; i < descativar.Length; i++)
            {
                descativar[i].SetActive(false);
            }
            direc.Play();
        }
    }

    IEnumerator Fin()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene("MainMenu");
    }
}
