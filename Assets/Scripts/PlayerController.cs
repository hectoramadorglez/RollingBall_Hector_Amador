using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public StormController stormController; 
    public float health = 100f;  

    void Update()
    {
       
        if (health <= 0)
        {
            Die();  
        }
    }

   
    void Die()
    {
       
        stormController.ResetStorm();

        
        Debug.Log("¡El jugador ha muerto!");

        
    }
}
