using UnityEngine;

public class EatFlesh : MonoBehaviour
{
    public FoodTimer foodTimer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerAttributes player = GetComponent<PlayerAttributes>();

            player.fleshEaten += 1;
            foodTimer.foodSlider.maxValue = 150f;
            foodTimer.foodCurrentValue = 150f;
            Destroy(gameObject);
        }
    }
}
