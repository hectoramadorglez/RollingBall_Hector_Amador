using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] int fuerza;
    Vector3 miVector = new Vector3(0,1,0);
    int puntuacion;
    [SerializeField] TMP_Text  textoPuntuacion;
    [SerializeField] private float distanciaRaycast;

    void Start()
    {
       rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.mass = 1;
        rb.drag = 4f;
    }

    // Update is called once per frame
    void Update()
    {
       


    }
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if(DetectaSuelo()) 
            {

                rb.AddForce(Vector3.up * fuerza, ForceMode.Impulse);

            }
            



        }
        rb.AddForce(new Vector3(h, 0, 0) * fuerza, ForceMode.Force);
        rb.AddForce(new Vector3(0, 0, v) * fuerza, ForceMode.Force);
        //rb.AddForce(new Vector3(h,0,v).normalized * fuerza, ForceMode.Force);

    }
    private void OnTriggerEnter(Collider other)
    {
        puntuacion += 10;
        textoPuntuacion.SetText("Score: "+ puntuacion);



    }
    private bool DetectaSuelo() 
    {
       bool resultado = Physics.Raycast(transform.position, new Vector3(0, -1, 0), distanciaRaycast);
        return resultado;  
    
    }
     
    
    
    
    
}
