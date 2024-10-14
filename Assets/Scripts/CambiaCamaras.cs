using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaCamaras : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject camaraA;
    [SerializeField] private GameObject camaraB;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            if (camaraA.activeSelf) 
            {
                camaraA.SetActive(false);
             
                camaraB.SetActive(true);


            }
            else 
            {
                camaraA.SetActive(true);

                camaraB.SetActive(false);

            }



        }
    }
}
