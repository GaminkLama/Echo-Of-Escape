
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
        // Sprawd�, czy obiekt ma EnemyHealth
        RunnerHealth enemy = collision.gameObject.GetComponent<RunnerHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(bulletDamage);
        }

        // Zniszcz pocisk w ka�dym przypadku
        Destroy(gameObject);
    }
}





