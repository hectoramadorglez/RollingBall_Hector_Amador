using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CanvasManager : MonoBehaviour
{
    
    // Start is called before the first frame update
   public void Play() 
    { 
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Exit() 
    { 
        Application.Quit();
    }


}
