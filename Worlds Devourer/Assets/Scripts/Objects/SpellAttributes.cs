using UnityEngine;

public class SpellAttributes : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.TakeDamage(damage);
        }
        else if (collision.TryGetComponent(out PlayerAttributes player))
        {
            player.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

}
