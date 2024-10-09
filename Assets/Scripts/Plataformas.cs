using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 direccion;
    [SerializeField] float velocidad;
    float timer = 0f;    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=5) 
        {
            transform.Translate(direccion * velocidad);
            timer = 0f;

        }
        
       
        
    }
}