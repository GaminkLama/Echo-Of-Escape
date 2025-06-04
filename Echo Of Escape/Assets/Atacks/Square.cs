
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private int attackDamage;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Sprawd�, czy obiekt ma EnemyHealth
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(attackDamage);
        }

    }
}
