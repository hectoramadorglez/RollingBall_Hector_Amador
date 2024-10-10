using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rodillo : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    [SerializeField]   int velocidad;
    [SerializeField] int fuerza;
    [SerializeField] private
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3 (0,0,0) * fuerza, ForceMode.Impulse);
       
    }

    // Update is called once per frame
    void Update()
    {
        

       
    }
}
