using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    public GameObject boss;
    public GameObject lockExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.SetActive(true);
            lockExit.SetActive(true);
        }
    }
}
