using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public RoomControler room; // Referencja do RoomControler, aby powiadomić o śmierci

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage. HP left: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (room == null)
        {
            room.OnEnemyKilled(gameObject);
            
        }
        Destroy(gameObject);
        
    }
}
