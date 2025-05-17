using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    public float moveSpeed = 5f;
    private Vector3 targetPosition;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

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
