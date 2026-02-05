using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerAttributes playerAttributes = collision.GetComponent<PlayerAttributes>();

            playerAttributes.hpSlider.maxValue += 50;
            Destroy(gameObject);
        }
    }
}
