using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    public GameObject boss;
    public GameObject lockExitA;
    public GameObject lockExitB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.SetActive(true);
            lockExitA.SetActive(true);
            lockExitB.SetActive(true);
        }
    }
}
