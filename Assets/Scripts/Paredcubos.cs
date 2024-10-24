using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Paredcubos : MonoBehaviour
{
    // Start is called before the first frame update
    private bool iniciarTimer;
    private  float timer = 0f;
    [SerializeField] private Rigidbody[] rbs;

    // Update is called once per frame
    void Update()
    {
        if (iniciarTimer == true)
        {
            timer += 1 * Time.unscaledDeltaTime;
            if (timer >= 2)
            {

                Time.timeScale = 1;
                for (int i = 0;i < rbs.Length; i++)
                {
                    rbs[i].useGravity = true;
                
                }         

            }


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {

            Time.timeScale = 0.1f;
            iniciarTimer = true;

        
        }


    }
}
