using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzLinterna : MonoBehaviour
{
    public Enemy enemigo;
    private void OnDisable()
    {
        enemigo.NoLight();
    }
}
