using UnityEngine;

public class AciropMovement : MonoBehaviour
{
    [SerializeField] private GameObject targetPlayer;
    public bool nextToTarget;

    [SerializeField] private float moveSpeed;
    public Transform TargetTransform => targetPlayer.transform;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(
            targetPlayer.transform.position,
            transform.position
        );

        if (distance <= 1.5f)
        {
            nextToTarget = true;
            rb.linearVelocity = Vector2.zero;
            return;
        }

        nextToTarget = false;

        Vector2 newPos = Vector2.MoveTowards(
            rb.position,
            targetPlayer.transform.position,
            moveSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(newPos);

        FlipToPlayer();
    }

    void FlipToPlayer()
    {
        Vector3 scale = transform.localScale;

        if (targetPlayer.transform.position.x > transform.position.x)
            scale.x = -Mathf.Abs(scale.x);
        else
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;
    }
}
