using UnityEngine;
using UnityEngine.SceneManagement; // do restartu gry
using UnityEngine.Events; // do zdarzenia OnHealthChanged
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;




    void Start()
    {
        currentHealth = maxHealth;
        if (OnHealthChanged == null)
        {
            OnHealthChanged = new UnityEvent();
        }

    }
    public UnityEvent OnHealthChanged;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Gracz otrzymał obrażenia. Pozostałe HP: " + currentHealth);

        OnHealthChanged.Invoke();

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
    public float RemainingHealthPercentage
    {
        get
        {
            return (float)currentHealth / maxHealth;
        }
    }
}
