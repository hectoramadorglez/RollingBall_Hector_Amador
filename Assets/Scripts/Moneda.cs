using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    // Start is called before the first frame update

    public float pauseDuration = 3f; // Duraci�n de la pausa de la tormenta

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Intentar encontrar el script de la tormenta en la escena
            StormDamage storm = FindObjectOfType<StormDamage>();

            if (storm != null)
            {
                // Pausar la tormenta durante el tiempo especificado
                storm.PauseStorm(pauseDuration);
            }

            // Destruir el recolectable despu�s de recogerlo
            Destroy(gameObject);
        }
    }
}
