using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyMaxHealth;
    [SerializeField] private float enemyCurrentHealth;
    [SerializeField] private GameObject flesh;
    [SerializeField] private GameObject enterBossArenaTrigger;
    [SerializeField] private PlayerAttack player;

    private void Awake()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    public void TakeDamage(float damage)
    {
        enemyCurrentHealth -= damage;
        if (enemyCurrentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        if(player.mistDescentUnlocked == false)
        {
            player.mistDescentUnlocked = true;
        }
        flesh.SetActive(true);
        Destroy(enterBossArenaTrigger);
        Destroy(gameObject);
    }
}
