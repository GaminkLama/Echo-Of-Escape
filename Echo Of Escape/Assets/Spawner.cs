using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner: MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private GameObject currentEnemy;

    void SpawnEnemy()
    {
        int index = Random.Range(0, spawnPoints.Length);
        currentEnemy = Instantiate(EnemyPrefab, spawnPoints[index].position, Quaternion.identity);
    }

    void Update()
    {
        if (currentEnemy == null)
        {
            SpawnEnemy();
        }
    }
}

