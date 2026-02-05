using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    [Header("Health")]
    public float hpCurrentValue;
    public float hpMaxValue;
    public Slider hpSlider;

    [Header("Mana")]
    public float manaCurrentValue;
    public float manaMaxValue;
    public Slider manaSlider;

    private void Start()
    {
        hpCurrentValue = hpMaxValue;
        manaCurrentValue = manaMaxValue;
    }

    private void Update()
    {
        hpMaxValue = hpSlider.maxValue;
        manaMaxValue = manaSlider.maxValue;

        hpSlider.value = hpCurrentValue;
        manaSlider.value = manaCurrentValue;

        if (hpCurrentValue <= hpMaxValue)
        {
            hpCurrentValue += 2.5f * Time.deltaTime;
        }

        if (manaCurrentValue <= manaMaxValue)
        {
            manaCurrentValue += 2.5f * Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {
        hpCurrentValue -= damage;

        if (hpCurrentValue <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Dead");
    }
}
