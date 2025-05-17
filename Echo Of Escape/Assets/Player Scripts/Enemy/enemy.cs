
using UnityEngine;

internal class enemy : MonoBehaviour
{
    public float ms;
    public Rigidbody body;

    private void Update()
    {
        var position = movement.Instance.transform.position;
        //body.MovePosition(position);
        transform.position = Vector2.MoveTowards(transform.position, position, ms * Time.deltaTime);
    }
}