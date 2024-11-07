using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjeRotacion : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidadRotacion = 100f;  // Velocidad de rotaci�n de las aspas

    void Update()
    {
        // Rota el eje de rotaci�n alrededor de su eje Y
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);
    }
}
