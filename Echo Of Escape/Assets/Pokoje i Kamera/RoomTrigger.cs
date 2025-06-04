using UnityEngine;
public class RoomTrigger : MonoBehaviour
{
    private bool activated = false;
    public RoomControler roomControler;
    void Start()
    {
        
        if (roomControler == null)
        {
            roomControler = FindObjectOfType<RoomControler>();
            if (roomControler == null)
            {
                Debug.LogError("RoomControler not found in the scene.");
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            activated = true;
            roomControler.SpawnEnemies(); // ← Tutaj najlepiej
        }
    }
}
