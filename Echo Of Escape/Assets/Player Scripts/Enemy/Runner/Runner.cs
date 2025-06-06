using UnityEngine;

public class Runner : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float stopDistance = 1.5f;
    private float damageCooldown = 1.5f; // ile czasu między obrażeniami
    private float lastDamageTime = -Mathf.Infinity;


    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Gracz z tagiem 'Player' nie został znaleziony!");
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > stopDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
    
    
        void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time >= lastDamageTime + damageCooldown)
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(1);
                lastDamageTime = Time.time;
            }
        }
    }


}
