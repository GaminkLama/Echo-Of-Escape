
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
        // Sprawdü, czy obiekt ma EnemyHealth
        RunnerHealth enemy = collision.gameObject.GetComponent<RunnerHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(attackDamage);
        }

    }
}
