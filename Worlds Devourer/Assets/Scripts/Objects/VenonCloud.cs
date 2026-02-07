using UnityEngine;

public class VenonCloud : MonoBehaviour
{
    [SerializeField] private float damage = 15f;
    [SerializeField] private float lifeTime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAttributes player = other.GetComponent<PlayerAttributes>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }

}
