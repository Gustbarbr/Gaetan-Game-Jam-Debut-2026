using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyMaxHealth;
    [SerializeField] private float enemyCurrentHealth;

    private void Awake()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    public void TakeDamage(float damage)
    {
        enemyCurrentHealth -= damage;

        if(enemyCurrentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
