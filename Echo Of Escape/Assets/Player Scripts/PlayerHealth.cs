using UnityEngine;
using UnityEngine.SceneManagement; // do restartu gry

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Gracz otrzymał obrażenia. Pozostałe HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Gracz zginął!");
        Destroy(gameObject);
        // Możesz pokazać ekran przegranej albo restart sceny:
        SceneManager.LoadSceneAsync(2);
    }
}
