using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    
    IEnumerator SpawnBallsAndWait()
    {
        while (true)
        {
            // Generar 4 bolas
            SpawnBalls();

            // Esperar 3 segundos antes de generar las siguientes bolas
            yield return new WaitForSeconds(spawnInterval);

            // Esperar 25 segundos antes de destruir las bolas generadas
            yield return new WaitForSeconds(destroyAfter);

            // Destruir todas las bolas generadas
            DestroyAllBalls();
        }
    }

    void SpawnBalls()
    {
        for (int i = 0; i < ballsPerSpawn; i++)
        {
            // Calcular una posición aleatoria dentro del área definida alrededor del spawnPoint
            float randomX = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
            float randomZ = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);

            // Crear la posición final para la bola sumando el desplazamiento aleatorio a la posición del spawnPoint
            Vector3 spawnPosition = spawnPoint + new Vector3(randomX, 0, randomZ);

            // Instanciar la bola en la posición calculada
            GameObject newBall = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
            // Agregar la bola a la lista para gestionarla más tarde
            spawnedBalls.Add(newBall);
        }
    }

    void DestroyAllBalls()
    {
        // Destruir todas las bolas almacenadas
        foreach (GameObject ball in spawnedBalls)
        {
            if (ball != null)
            {
                Destroy(ball);
            }
        }

        // Limpiar la lista de bolas
        spawnedBalls.Clear();
    }
}
