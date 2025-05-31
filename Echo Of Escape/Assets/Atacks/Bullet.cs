
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime;
    public int bulletDamage;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Sprawdü, czy obiekt ma EnemyHealth
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(bulletDamage);
        }

        // Zniszcz pocisk w kaødym przypadku
        Destroy(gameObject);
    }
}





