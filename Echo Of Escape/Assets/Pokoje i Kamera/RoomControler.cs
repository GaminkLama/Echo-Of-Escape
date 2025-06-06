using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControler : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // 3 typy przeciwników
    public Transform roomCenter; // punkty spawnu w pokoju
    public float roomWidth = 10f; // szerokość pokoju
    public float roomHeight = 6f; // wysokość pokoju
    public int enemiesToSpawn = 5;
    private List<GameObject> aliveEnemies = new List<GameObject>();

    public bool disableSpawning = false;

    public GameObject[] doors; // drzwi do zamknięcia

    private void Awake()
    {
        if (roomCenter == null)
        {
            roomCenter = transform.Find("RoomCenter");
        }

        if (doors == null || doors.Length == 0)
        {
            doors = GameObject.FindGameObjectsWithTag("Door"); // lub lepiej: przeszukaj tylko dzieci
            Debug.Log("Automatycznie przypisano drzwi do: " + gameObject.name);
        }
    }



    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            CloseDoors();
            SpawnEnemies();
            if (!disableSpawning)
                SpawnEnemies();
        }
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);

            float offsetX = Random.Range(-roomWidth / 2f, roomWidth / 2f);
            float offsetY = Random.Range(-roomHeight / 2f, roomHeight / 2f);
            Vector2 spawnPos = new Vector2(roomCenter.position.x + offsetX, roomCenter.position.y + offsetY);

            GameObject enemy = Instantiate(enemyPrefabs[randEnemy], spawnPos, Quaternion.identity);

            EnemyHealth health = enemy.GetComponent<EnemyHealth>();
            if (health != null)
            {
            health.room = this; // Jeśli `EnemyHealth` ma zmienną `room`
            }
        }
    }


    public void OnEnemyKilled(GameObject enemy)
    {
        aliveEnemies.Remove(enemy);
        if (aliveEnemies.Count == 0)
        {
            OpenDoors();
        }
    }

    void CloseDoors()
    {
        foreach (GameObject door in doors)
            door.SetActive(true); // lub animacja zamknięcia
    }

    void OpenDoors()
    {
        foreach (GameObject door in doors)
            door.SetActive(false); // lub animacja otwarcia
    }
}
