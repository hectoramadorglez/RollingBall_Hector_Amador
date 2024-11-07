using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helices : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float fuerzaLanzamiento = 30f;  

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
