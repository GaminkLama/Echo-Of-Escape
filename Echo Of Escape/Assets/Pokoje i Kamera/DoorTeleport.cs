using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    public Vector2Int direction; // np. (0, 1) dla góry
    public float roomSpacing = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Oblicz now¹ pozycjê gracza
            Vector3 offset = new Vector3(direction.x, direction.y, 0) * roomSpacing;
            other.transform.position += offset;
        }
    }
}
