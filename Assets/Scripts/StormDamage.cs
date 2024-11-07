using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StormDamage : MonoBehaviour
{


    public float damagePerSecond = 5f;    
    public float speed = 5f;             
    public Vector3 moveDirection = Vector3.forward;
    public float startDelay = 5f;          

    private bool isInStorm = false;       
    private bool isMoving = false;         
    private bool isPaused = false;         
    private PlayerHealth playerHealth;     
    private Renderer playerRenderer;       
    private Coroutine blinkCoroutine;      
    private float countdownTimer;          

    private void Start()
    {
        
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        playerRenderer = playerHealth.GetComponent<Renderer>(); 
        if (playerHealth == null || playerRenderer == null)
        {
            Debug.LogError("No se encontró el componente de salud o Renderer del jugador");
        }

       
        countdownTimer = startDelay;
    }

    private void Update()
    {
        
        if (!isMoving)
        {
            CountdownBeforeMovement();
        }
        else if (!isPaused)  
        {
            MoveStorm();
        }

        
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
       
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            isInStorm = true;

            
            if (blinkCoroutine == null)
            {
                blinkCoroutine = StartCoroutine(BlinkPlayer());
            }
        }
        else if (other.CompareTag("Recolectable"))
        {
           
            StartCoroutine(PauseStorm());

            
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInStorm = false;

            
            if (blinkCoroutine != null)
            {
                StopCoroutine(blinkCoroutine);
                blinkCoroutine = null;

                
                playerRenderer.material.color = Color.white;
            }
        }
    }

    
    private IEnumerator BlinkPlayer()
    {
        while (isInStorm)
        {
            
            Color randomColor = new Color(Random.value, Random.value, Random.value);

            
            playerRenderer.material.color = randomColor;

            
            yield return new WaitForSeconds(0.2f);
        }
    }

    
    public IEnumerator PauseStorm()
    {
        isPaused = true;  
        yield return new WaitForSeconds(3f);  
        isPaused = false;  
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
