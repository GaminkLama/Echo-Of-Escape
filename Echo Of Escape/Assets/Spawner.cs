using UnityEngine;

public class Spawner: MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private GameObject currentEnemy;

    void SpawnEnemy()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Vector2 spawnPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-3f, 3f));
        currentEnemy = Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);

    }

    void Update()
    {
        if (currentEnemy == null)
        {
            SpawnEnemy();
        }
    }
}

