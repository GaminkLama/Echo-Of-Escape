using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            rb.AddForce(movement.normalized * speed);
        }
    }  
}


