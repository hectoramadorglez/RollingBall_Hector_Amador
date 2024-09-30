using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 miVector = new Vector3(0,0,0);
    [SerializeField] int velocidad = 2;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,0) * velocidad);
    }
}
