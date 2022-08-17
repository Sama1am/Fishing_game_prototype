using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject currentPoint;
    int index;

    public Rigidbody2D[] enemies;
    public float minTimeBetweenSpawns;
    public float maxTimeBetweenSpawns;
    public bool canSpawn;
    public float spawnTime;
    public int enemiesInGame;
    public bool spawnerDone;

    private void Start()
    {
        Invoke("SpawnEnemy", 0.5f);
    }

    private void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            spawnerDone = true;
            canSpawn = false;
            spawnTime = 0;
        }
    }
        void SpawnEnemy()
    {
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);

        if (canSpawn)
        {
            Rigidbody2D fish = Instantiate(enemies[Random.Range(0, enemies.Length)], currentPoint.transform.position, Quaternion.identity);
            fish.transform.parent = currentPoint.transform;
            enemiesInGame++;
        }

        Invoke("SpawnEnemy", timeBetweenSpawns);

        if(spawnerDone)
        {
            Debug.Log("Spawning Complete");
        }
    }
}
