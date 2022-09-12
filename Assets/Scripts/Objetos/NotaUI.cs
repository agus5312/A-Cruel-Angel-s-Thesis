using UnityEngine;

public class NotaUI : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E))
            gameObject.SetActive(false);
    }
}
