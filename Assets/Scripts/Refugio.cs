using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Refugio : MonoBehaviour
{
   
    public string sceneName = "MenuScene";

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1 );
        }
    }
    
}
