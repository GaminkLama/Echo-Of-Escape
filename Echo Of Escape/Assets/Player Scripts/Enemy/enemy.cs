using UnityEngine;

internal class enemy : MonoBehaviour
{
    public float ms;
    public Rigidbody2D body;

    private void Update()
    {
        var position = PlayerMovement.Instance.transform.position;
        //body.MovePosition(position);
        transform.position = Vector2.MoveTowards(transform.position, position, ms * Time.deltaTime);
    }
}