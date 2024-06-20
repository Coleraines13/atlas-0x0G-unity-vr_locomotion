using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public ZombieAI zombieAI;

    void Start()
    {
        currentHealth = maxHealth;
        if (zombieAI == null)
        {
            Debug.LogError("ZombieAI reference not set. Ensure the Player has a reference to the ZombieAI script.");
        }
        else
        {
            Debug.Log("ZombieAI reference successfully set.");
        }
    }

    void Update()
    {
        if (zombieAI != null && zombieAI.IsAttacking())
        {
            Debug.Log("Zombie is attacking. Player will take damage.");
            TakeDamage(2);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died.");
        // Add death logic here (e.g., disable player controls, play death animation, etc.)
    }
}