using UnityEngine;

public class movement : MonoBehaviour
{
    Vector2 move;
    [SerializeField] private int speed;
    Rigidbody2D rb;

    public static movement Instance { get; private set; }

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
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    void FixedUpdate()
    {
        rb.velocity = move * speed;   
    }  
}


