
using UnityEngine;

public class RunnerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"{gameObject.name} HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        Destroy(gameObject);
    }
}

