using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField] int velocity;


    void Update()
    {
        transform.Rotate(velocity * Time.deltaTime, 0, 0);

    }

    
}
