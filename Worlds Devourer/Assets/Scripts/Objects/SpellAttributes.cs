using UnityEngine;

public class SpellAttributes : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();

            enemy.TakeDamage(damage);

            Destroy(gameObject);
        }

        if(collision.CompareTag("Breakable Wall"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
