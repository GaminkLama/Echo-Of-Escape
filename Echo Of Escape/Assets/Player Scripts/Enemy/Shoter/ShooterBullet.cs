using UnityEngine;

public class ShooterBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    public int bulletDamage = 1;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Szukamy komponentu PlayerHealth w obiekcie, w który uderzyliśmy
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(bulletDamage);
                Debug.Log("Gracz trafiony!");
            }

            Destroy(gameObject);
        }
        else if (!collision.isTrigger)
        {
            Destroy(gameObject); // zderzył się z czymś innym, np. ścianą
        }
    }
}
