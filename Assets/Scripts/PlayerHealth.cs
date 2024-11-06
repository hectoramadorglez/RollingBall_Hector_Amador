using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100f;
    private float currentHealth;
    private bool isDead = false;
    private Vector3 initialPosition;
    void Start()
    {
        currentHealth = maxHealth;
        initialPosition = transform.position;
    }

    // Update is called once per frame

    public void TakeDamage(float amount)
    {
        if (isDead) return;
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Salud actual del jugador: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

        isDead = true;
        Debug.Log("El jugador ha muerto");


        gameObject.SetActive(false);


        Invoke("Respawn", 2f);
    }
    private void Respawn()
    {
        
        currentHealth = maxHealth;
        isDead = false;  

        
        transform.position = initialPosition;

      
        gameObject.SetActive(true);

        Debug.Log("El jugador ha reaparecido en el punto inicial con salud completa.");
    }
}