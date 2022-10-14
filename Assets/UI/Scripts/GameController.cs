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
    //[SerializeField] GameObject SaveButton;

    bool pausa = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa)
            {
                BotonReplay();
                pausa = false;
            }
            else
            {
                BotonPausa();
                pausa = true;
            }
        }
    }
    public void BotonPausa()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void BotonReplay()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerPrefs.Save();
    }
    public void ToInicio(string name)
    {
        Time.timeScale = 1;
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
        //SaveButton.SetActive(false);
    }
    public void DesaparecerSliderSound()
    {
        Sound.SetActive(false);
        BackToMenuB.SetActive(true);
        BackSliderB.SetActive(false);
        QuitButton.SetActive(true);
        SoundButton.SetActive(true);
        //SaveButton.SetActive(true);
    }
    public void AparecerSliderBrillo()
    {
        Brillo.SetActive(true);
        BackToMenuB.SetActive(false);
        BackSliderB.SetActive(true);
        QuitButton.SetActive(false);
        BrilloButton.SetActive(false);
        //SaveButton.SetActive(false);
    }
    public void DesaparecerSliderBrillo()
    {
        Brillo.SetActive(false);
        BrilloButton.SetActive(true);
        BackSliderB.SetActive(false);
        QuitButton.SetActive(true);
        BackToMenuB.SetActive(true);
        //SaveButton.SetActive(true);
    }
}
