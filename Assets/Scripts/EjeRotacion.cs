using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjeRotacion : MonoBehaviour
{
    
    public float velocidadMinima = 50f;  
    public float velocidadMaxima = 150f; 
    private float velocidadRotacion;

    void Start()
    {
        
        velocidadRotacion = Random.Range(velocidadMinima, velocidadMaxima);
    }

    void Update()
    {
        
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);
    }
}
