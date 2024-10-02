using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] Vector3 direccion;
    [SerializeField] float velocidad;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direccion * velocidad * Time.deltaTime,Space.World);
    }
}
