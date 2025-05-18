using UnityEngine;

public class CameraControllerIsaac : MonoBehaviour
{
    public Transform player;
    public Vector2 roomSize = new Vector2(16f, 9f); // szerokoœæ i wysokoœæ pokoju
    public float smoothSpeed = 5f;

    private Vector3 targetPos;

    void LateUpdate()
    {
        int roomX = Mathf.FloorToInt(player.position.x / roomSize.x);
        int roomY = Mathf.FloorToInt(player.position.y / roomSize.y);

        targetPos = new Vector3(roomX * roomSize.x, roomY * roomSize.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothSpeed);
    }
}
