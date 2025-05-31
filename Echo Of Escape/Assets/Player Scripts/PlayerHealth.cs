using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerMaxHealth = 5;
    public int PlayerCurrentHealth;

    void Start()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
    }

    public void TakeDamage(int amount)
    {
        PlayerCurrentHealth -= amount;
        Debug.Log($"Gracz otrzyma� {amount} obra�e�. Pozosta�o HP: {PlayerCurrentHealth}");

        if (PlayerCurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Gracz zgin��.");
        // np. respawn, koniec gry, itp.
    }
}
