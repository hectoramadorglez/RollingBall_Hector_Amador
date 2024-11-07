using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StormDamage : MonoBehaviour
{


    public float damagePerSecond = 5f;     // Daño que causa la tormenta por segundo
    public float speed = 5f;               // Velocidad de movimiento de la tormenta
    public Vector3 moveDirection = Vector3.forward; // Dirección de movimiento
    public float startDelay = 5f;          // Retraso antes de que la tormenta comience a moverse

    private bool isInStorm = false;        // Indica si el jugador está en la tormenta
    private bool isMoving = false;         // Indica si la tormenta está en movimiento
    private bool isPaused = false;         // Indica si la tormenta está pausada temporalmente
    private PlayerHealth playerHealth;     // Referencia al componente de salud del jugador
    private Renderer playerRenderer;       // Referencia al renderer del jugador para cambiar su color
    private Coroutine blinkCoroutine;      // Almacena la corrutina de parpadeo
    private float countdownTimer;          // Temporizador de cuenta regresiva

    private void Start()
    {
        // Buscar el componente de salud del jugador
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        playerRenderer = playerHealth.GetComponent<Renderer>(); // Obtener el Renderer del jugador
        if (playerHealth == null || playerRenderer == null)
        {
            Debug.LogError("No se encontró el componente de salud o Renderer del jugador");
        }

        // Inicializar el temporizador
        countdownTimer = startDelay;
    }

    private void Update()
    {
        // Controlar la cuenta regresiva antes de que la tormenta comience a moverse
        if (!isMoving)
        {
            CountdownBeforeMovement();
        }
        else if (!isPaused)  // Mover la tormenta solo si está en movimiento y no está pausada
        {
            MoveStorm();
        }

        // Aplicar daño si el jugador está en la tormenta
        if (isInStorm && playerHealth != null)
        {
            playerHealth.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }

    private void CountdownBeforeMovement()
    {
        if (countdownTimer > 0)
        {
            countdownTimer -= Time.deltaTime;
        }
        else
        {
            StartStormMovement();
        }
    }

    private void StartStormMovement()
    {
        isMoving = true;
    }

    private void MoveStorm()
    {
        // Mover la tormenta en la dirección indicada
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime);
    }

    // Activar el daño y el efecto de parpadeo cuando el jugador entra en la zona de tormenta
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
        else if (other.CompareTag("Recolectable"))
        {
            // Pausar la tormenta por 3 segundos al recoger un objeto recolectable
            StartCoroutine(PauseStorm());

            // Destruir el objeto recolectable
            Destroy(other.gameObject);
        }
    }

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

    // Corrutina para hacer parpadear al jugador con colores aleatorios
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

    // Corrutina para pausar temporalmente el movimiento de la tormenta
    public IEnumerator PauseStorm()
    {
        isPaused = true;  // Pausar la tormenta
        yield return new WaitForSeconds(3f);  // Esperar 3 segundos
        isPaused = false;  // Reanudar el movimiento de la tormenta
    }
    private IEnumerator PauseStormCoroutine(float duration)
    {
        isPaused = true;            
        yield return new WaitForSeconds(duration);  
        isPaused = false;           
    }
    public void PauseStorm(float duration) 
    { 
        StartCoroutine(PauseStormCoroutine(duration));
    
    }
}
