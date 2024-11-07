using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helices : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float fuerzaLanzamiento = 30f;  // Fuerza de lanzamiento para el jugador

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisiona es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rbJugador = collision.gameObject.GetComponent<Rigidbody>();
            if (rbJugador != null)
            {
                // Calcular la dirección de lanzamiento
                Vector3 direccionLanzamiento = collision.transform.position - transform.position;
                direccionLanzamiento.y = 1; // Añadir elevación hacia arriba para lanzar al jugador en diagonal
                direccionLanzamiento.Normalize();

                // Aplicar la fuerza al jugador
                rbJugador.AddForce(direccionLanzamiento * fuerzaLanzamiento, ForceMode.Impulse);
            }
        }
    }
}
