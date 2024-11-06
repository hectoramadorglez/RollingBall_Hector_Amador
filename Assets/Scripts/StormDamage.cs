using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StormDamage : MonoBehaviour
{


    public float damagePerSecond = 5f;     // Daño que causa la tormenta por segundo
    public float speed = 5f;
    private Renderer playerRenderer;       // Referencia al Renderer del jugador para cambiar su color
    private Coroutine blinkCoroutine;
    public Vector3 moveDirection = Vector3.forward; // Dirección de movimiento

    private bool isInStorm = false;        // Indica si el jugador está en la tormenta
    private bool isMoving = false;         // Indica si la tormenta está en movimiento
    private PlayerHealth playerHealth;     // Referencia al componente de salud del jugador

    private void Start()
    {
        // Buscar el componente de salud del jugador
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        playerRenderer = playerHealth.GetComponent<Renderer>();
        if (playerHealth == null || playerRenderer == null)
        {
            Debug.LogError("No se encontró el componente de salud o Renderer del jugador");
        }


        // Iniciar la tormenta después de 5 segundos
        Invoke("StartStormMovement", 5f);
    }

    private void Update()
    {
        // Mover la tormenta si está en movimiento
        if (isMoving)
        {
            MoveStorm();
        }

        // Si el jugador está en la tormenta, aplicar daño
        if (isInStorm && playerHealth != null)
        {
            playerHealth.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }

    // Método para iniciar el movimiento de la tormenta
    private void StartStormMovement()
    {
        isMoving = true;
    }

    private void MoveStorm()
    {
        // Mover la tormenta en la dirección indicada
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime);
    }

    // Activar el daño de tormenta cuando el jugador entra en la zona de tormenta
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInStorm = true;

            // Iniciar el efecto de parpadeo
            if (blinkCoroutine == null)
            {
                blinkCoroutine = StartCoroutine(BlinkPlayer());
            }
        }
    }

    // Desactivar el daño de tormenta cuando el jugador sale de la zona de tormenta
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInStorm = false;

            // Detener el efecto de parpadeo
            if (blinkCoroutine != null)
            {
                StopCoroutine(blinkCoroutine);
                blinkCoroutine = null;

                // Restaurar el color original del jugador
                playerRenderer.material.color = Color.white;
            }
        }
    }
    private IEnumerator BlinkPlayer()
    {
        while (isInStorm)
        {
            // Generar un color aleatorio
            Color randomColor = new Color(Random.value, Random.value, Random.value);

            // Cambiar el color del jugador
            playerRenderer.material.color = randomColor;

            // Esperar un corto período antes de cambiar el color nuevamente
            yield return new WaitForSeconds(0.2f);
        }
    }
}
