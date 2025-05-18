using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerIsaac : MonoBehaviour
{
    public static CameraControllerIsaac Instance;

    public float moveSpeed = 5f;
    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    public void MoveToRoom(Vector2 roomCenter)
    {
        targetPosition = new Vector3(roomCenter.x, roomCenter.y, transform.position.z);
    }
}
