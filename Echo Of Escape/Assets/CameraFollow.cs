using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 targetPosition;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }

    public void MoveToRoom(Vector2Int gridPos, float spacing)
    {
        targetPosition = new Vector3(gridPos.x * spacing, gridPos.y * spacing, -10f);
    }
}
