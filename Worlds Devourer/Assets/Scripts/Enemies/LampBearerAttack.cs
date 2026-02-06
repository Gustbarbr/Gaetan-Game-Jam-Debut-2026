using System.Collections;
using UnityEngine;

public class LampBearerAttack : MonoBehaviour
{
    public GameObject player;
    public Animator animator;

    [Header("Prefab")]
    [SerializeField] private GameObject mistDescentPrefab;
    [SerializeField] private Vector3 prefabSpawnPosition;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
            animator.SetBool("isAttacking", true);
            yield return new WaitForSeconds(0.5f);
            animator.SetBool("isAttacking", false);
        }
    }
}
