using UnityEngine;

public class NotaUI : MonoBehaviour
{
    AudioSource audi;

    private void OnEnable()
    {
        audi = GetComponent<AudioSource>();
        audi.Play();
    }
    private void OnDisable()
    {
        audi.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E))
            gameObject.SetActive(false);
    }
}
