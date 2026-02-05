using System.Collections;
using UnityEngine;

public class LampBearerAttack : MonoBehaviour
{
    public GameObject player;

    [Header("Prefab")]
    [SerializeField] private GameObject mistDescentPrefab;
    [SerializeField] private Vector3 prefabSpawnPosition;

    private void Start()
    {
        StartCoroutine(AttackInterval());
    }

    private void Update()
    {
        prefabSpawnPosition = new Vector3(player.transform.position.x, player.transform.position.y + 5f, transform.position.z);
    }

    IEnumerator AttackInterval()
    {
        while (true)
        {
            prefabSpawnPosition = new Vector3(
                player.transform.position.x,
                player.transform.position.y + 5f,
                transform.position.z
            );

            Instantiate(mistDescentPrefab, prefabSpawnPosition, transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
