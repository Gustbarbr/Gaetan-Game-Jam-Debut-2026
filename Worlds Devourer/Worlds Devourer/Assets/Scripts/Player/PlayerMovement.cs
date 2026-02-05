using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    [HideInInspector] public Rigidbody2D rb;
    private PlayerInputActions playerControls;
    Vector2 moveDirection;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputActions();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        moveDirection = playerControls.Player.Move.ReadValue<Vector2>();

        if(moveDirection.x != 0 )
        {
            animator.SetBool("isWalking", true);
        }
        else if (moveDirection.x == 0)
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * playerSpeed, rb.linearVelocity.y);

        if(moveDirection.x > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        if (moveDirection.x < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }
}
