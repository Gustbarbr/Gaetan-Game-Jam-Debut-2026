using UnityEngine;
using UnityEngine.UI;

public class FoodTimer : MonoBehaviour
{
    [SerializeField] private GameObject flesh;
    [SerializeField] private PlayerAttributes player;

    [Header("Food")]
    public float foodCurrentValue;
    public float foodMaxValue;
    public Slider foodSlider;

    private void Start()
    {
        foodCurrentValue = foodMaxValue;
    }

    private void Update()
    {
        foodSlider.value = foodCurrentValue;

        foodCurrentValue -= 1f * Time.deltaTime;

        if(foodCurrentValue <= 0)
        {
            player.Die();
        }
    }
}
