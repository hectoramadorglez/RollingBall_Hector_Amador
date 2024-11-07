using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidadMinima = 2f;       
    public float velocidadMaxima = 4f;        
    public float distanciaMovimiento = 5f;    

    private float velocidadMovimiento;
    private Vector3 posicionInicial;

    void Start()
    {
        
        posicionInicial = transform.position;

        
        velocidadMovimiento = Random.Range(velocidadMinima, velocidadMaxima);
    }

    void Update()
    {
        
        float desplazamiento = Mathf.PingPong(Time.time * velocidadMovimiento, distanciaMovimiento * 2) - distanciaMovimiento;

        
        transform.position = new Vector3(posicionInicial.x + desplazamiento, posicionInicial.y, posicionInicial.z);
    }
}
