using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] int fuerza;
    Vector3 miVector = new Vector3(0,1,0);
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
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(new Vector3(0,1,0) * fuerza, ForceMode.Impulse);
            
        
        
        }
        rb.AddForce (new Vector3(h,0,0)* fuerza, ForceMode.Force);
        rb.AddForce(new Vector3(0, 0, v) * fuerza, ForceMode.Force);


    }
}
