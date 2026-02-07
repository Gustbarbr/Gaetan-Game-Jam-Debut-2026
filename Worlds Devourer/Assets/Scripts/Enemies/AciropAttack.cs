using System.Collections;
using UnityEngine;

public class AciropAttack : MonoBehaviour
{
    [SerializeField] private GameObject venonCloudPrefab;
    [SerializeField] private float attackCooldown = 3f;
    [SerializeField] private float spawnOffset = 2f;

    private AciropMovement aciropMovement;
    private Animator animator;
    private Rigidbody2D rb;

    private bool isAttacking;

    private void Awake()
    {
        aciropMovement = GetComponent<AciropMovement>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (aciropMovement.nextToTarget && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;

        while (aciropMovement.nextToTarget)
        {
            float direction = Mathf.Sign(
                aciropMovement.TargetTransform.position.x - rb.position.x
            );

            Vector2 spawnPos = rb.position + Vector2.right * direction * spawnOffset;

            animator.SetBool("isAttacking", true);
            Instantiate(venonCloudPrefab, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(attackCooldown);

            animator.SetBool("isAttacking", false);
        }

        isAttacking = false;
    }
}
