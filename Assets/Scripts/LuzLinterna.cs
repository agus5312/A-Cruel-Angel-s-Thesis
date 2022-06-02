using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzLinterna : MonoBehaviour
{
    public Frogger enemigo;
    private void OnDisable()
    {
        enemigo.NoLight();
    }
}
