using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormController : MonoBehaviour
{
     
    public float moveSpeed = 2f; 
      

    public GameObject storm;  
    public Transform posicioninicialtormenta;  
    private Vector3 initialPosition;  
    private bool stormActive = true;  
    void Start()
    {
       
        initialPosition = storm.transform.position;
        if (posicioninicialtormenta != null)
        {
            initialPosition = posicioninicialtormenta.position;  
        }
    }

    void Update()
    {
        
        if (stormActive)
        {
            storm.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    
    public void ResetStorm()
    {
        stormActive = false;  
        storm.transform.position = initialPosition;  
        stormActive = true;
    }
}
