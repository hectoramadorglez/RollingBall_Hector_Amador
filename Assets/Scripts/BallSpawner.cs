using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{


    public GameObject ballPrefab;       
    public Vector3 spawnPoint = new Vector3(0, 35, 160); 
    public float spawnInterval = 2f;     
    public Vector2 spawnAreaSize = new Vector2(5f, 5f); 
    private float spawnTimer; 
    private bool canSpawn = true; 

    void Update()
    {
        
        if (canSpawn)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnInterval)
            {
                SpawnBall(); 
                spawnTimer = 0f; 
                canSpawn = false; 
            }
        }
    }

    void SpawnBall()
    {
        
        float randomX = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float randomZ = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);

        
        Vector3 spawnPosition = spawnPoint + new Vector3(randomX, 0, randomZ);

        
        Instantiate(ballPrefab, spawnPosition, Quaternion.identity);

        
        canSpawn = true;
    }
}
