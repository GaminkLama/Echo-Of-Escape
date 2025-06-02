using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Vector3 offset;
    void Update()
    {
        if (Player != null) 
        {
            transform.position = Player.position + offset;
        }
    }
}
