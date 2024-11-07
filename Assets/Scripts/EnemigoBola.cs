using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBola : MonoBehaviour
{
    
    public float pushForce = 15f;

    private void OnCollisionEnter(Collision collision)
{
    
    if (collision.gameObject.CompareTag("Player"))
    {
       
        Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

        if (playerRb != null)
        {
            
            Vector3 pushDirection = collision.transform.position - transform.position;
            pushDirection.y = 0; 
            pushDirection.Normalize();

            
            playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
}
