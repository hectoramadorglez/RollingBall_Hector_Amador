using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBola : MonoBehaviour
{
    // Start is called before the first frame update
    public float pushForce = 5f;

    private void OnCollisionEnter(Collision collision)
{
    // Comprobar si la bola colisionó con el jugador
    if (collision.gameObject.CompareTag("Player"))
    {
        // Obtener el Rigidbody del jugador
        Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

        if (playerRb != null)
        {
            // Calcular la dirección de empuje desde la bola hacia el jugador
            Vector3 pushDirection = collision.transform.position - transform.position;
            pushDirection.y = 0; // Mantener la dirección horizontal para que no lo empuje hacia arriba o abajo
            pushDirection.Normalize();

            // Aplicar la fuerza de empuje al jugador
            playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
}
