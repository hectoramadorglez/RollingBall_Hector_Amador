using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    // Start is called before the first frame update

    public float pauseDuration = 3f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            StormDamage storm = FindObjectOfType<StormDamage>();

            if (storm != null)
            {
                
                storm.PauseStorm(pauseDuration);
            }

            
            Destroy(gameObject);
        }
    }
}
