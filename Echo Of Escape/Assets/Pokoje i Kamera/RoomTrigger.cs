using UnityEngine;
public class RoomTrigger : MonoBehaviour
{
    private bool activated = false;
    public RoomControler roomControler;
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            activated = true;
            roomControler.SpawnEnemies(); // ← Tutaj najlepiej
        }
    }
}
