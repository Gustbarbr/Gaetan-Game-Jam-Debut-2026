using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerAttributes playerAttributes = collision.GetComponent<PlayerAttributes>();

            playerAttributes.manaSlider.maxValue += 50;
            Destroy(gameObject);
        }
    }
}
