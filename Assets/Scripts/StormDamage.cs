using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormDamage : MonoBehaviour
{
    

    public float damagePerSecond = 5f;
    private bool isInStorm = false;
    private PlayerHealth playerHealth;
    public float speed = 5f;               
    public Vector3 moveDirection = Vector3.forward;

    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        if(playerHealth == null)
        {

            Debug.LogError("No se encontro el componente de salud del jugador");
        }
    }

    
    void Update()
    {
        MoveStorm();
        if (isInStorm && playerHealth != null) 
        { 
        
            playerHealth.TakeDamage(damagePerSecond * Time.deltaTime);
        
        }  
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInStorm = true;
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInStorm = false;
        }
    }
    private void MoveStorm()
    {
        
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime);
    }
}
