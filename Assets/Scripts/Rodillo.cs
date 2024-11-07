using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rodillo : MonoBehaviour
{
    
    public float velocidadRotacion = 50f;
    public float fuerzaLanzamiento = 10f;

    void Update()
    {
       
        transform.Rotate(0, velocidadRotacion * Time.deltaTime, 0);
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rbJugador = collision.gameObject.GetComponent<Rigidbody>();
            if (rbJugador != null)
            {
               
                Vector3 direccionLanzamiento = collision.transform.position - transform.position;
                direccionLanzamiento.y = 1; 
                direccionLanzamiento.Normalize();

               
                rbJugador.AddForce(direccionLanzamiento * fuerzaLanzamiento, ForceMode.Impulse);
            }
        }
    }
}
