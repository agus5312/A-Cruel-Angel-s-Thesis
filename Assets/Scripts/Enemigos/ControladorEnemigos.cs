using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemigos : MonoBehaviour
{
    [SerializeField] List<GameObject> enemigos;
    /// <summary>
    /// Lista de enemigos
    /// </summary>
    public List<GameObject> Enemigos 
        {
         get{return enemigos;}
        }
}
