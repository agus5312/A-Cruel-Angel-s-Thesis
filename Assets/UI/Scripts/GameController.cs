using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject menuPausa;
    [SerializeField] GameObject estaSeguro;
    [SerializeField] GameObject Sound;
    [SerializeField] GameObject Brillo;
    [SerializeField] GameObject SoundButton;
    [SerializeField] GameObject BrilloButton;
    [SerializeField] GameObject BackButton;
    [SerializeField] GameObject BackSliderB;
    [SerializeField] GameObject BackToMenuB;
    [SerializeField] GameObject QuitButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            BotonPausa();
        }
    }
    public void BotonPausa()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
    }
    public void BotonReplay()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
    }
    public void ToInicio(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void panel()
    {
        estaSeguro.SetActive(true);
    }
    public void salirno()
    {
        estaSeguro.SetActive(false);
    }
    public void salirsi()
    {
        Debug.Log("Se salio del juego");
        Application.Quit();
    }
    public void AparecerSliderSound()
    {
        Sound.SetActive(true);
        BackSliderB.SetActive(true);
        BackToMenuB.SetActive(false);
        QuitButton.SetActive(false);
        SoundButton.SetActive(false);
    }
    public void DesaparecerSliderSound()
    {
        Sound.SetActive(false);
        SoundButton.SetActive(true);
        BackSliderB.SetActive(false);
        QuitButton.SetActive(true);
        SoundButton.SetActive(true);
    }
    public void AparecerSliderBrillo()
    {
        Brillo.SetActive(true);
        BrilloButton.SetActive(false);
        BackSliderB.SetActive(true);
        QuitButton.SetActive(false);
        SoundButton.SetActive(false);
    }
    public void DesaparecerSliderBrillo()
    {
        Brillo.SetActive(false);
        BrilloButton.SetActive(true);
        BackSliderB.SetActive(false);
        QuitButton.SetActive(true);
        SoundButton.SetActive(true); 
    }
}
