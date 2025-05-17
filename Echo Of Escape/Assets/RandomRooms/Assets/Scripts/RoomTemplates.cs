using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;
    void Awake()
    {
        // Ensure Entry Room is not destroyed
        if (GameObject.Find("Entry Room") != null)
            DontDestroyOnLoad(GameObject.Find("Entry Room"));
    }
    void Update()
    {
        if (waitTime <= 0 && !spawnedBoss)
        {
            // Clean up null/destroyed rooms first
            rooms.RemoveAll(room => room == null);

            if (rooms.Count > 0)
            {
                // Get last active room
                GameObject lastRoom = rooms[rooms.Count - 1];
                if (lastRoom != null)
                {
                    Instantiate(boss, lastRoom.transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}