using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] float spawnRate = 2f;
    [SerializeField] float tankSpawnRate = 10;
    [SerializeField] float shooterSpawnRate = 4;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject tankPrefab;
    [SerializeField] GameObject shooterPrefab;

    [SerializeField] float tankInitialDelay = 5f; // Time delay for the first tank spawn
    [SerializeField] float shooterInitialDelay = 3f;

    float xMin;
    float xMax;
    float ySpawn;

    // Start is called before the first frame update
    void Start()
    {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0, 0)).x;
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(.9f, 0, 0)).x;
        ySpawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;
        InvokeRepeating("SpawnEnemy", 0, spawnRate);
        InvokeRepeating("SpawnTank", tankInitialDelay, tankSpawnRate);
        InvokeRepeating("SpawnShooter", shooterInitialDelay, shooterSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randx = Random.Range(xMin, xMax);
        Instantiate(enemyPrefab, new Vector3(randx, ySpawn, 0), Quaternion.identity);
    }

    void SpawnTank()
    {
        float randx = Random.Range(xMin, xMax);
        Instantiate(tankPrefab, new Vector3(randx, ySpawn, 0), Quaternion.identity);
    }

    void SpawnShooter()
    {
        float randx = Random.Range(xMin, xMax);
        Instantiate(shooterPrefab, new Vector3(randx, ySpawn, 0), Quaternion.identity);
    }
}
