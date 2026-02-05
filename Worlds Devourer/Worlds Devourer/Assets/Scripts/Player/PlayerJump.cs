using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private PlayerInputActions playerControls;

    public PlayerMovement player;

    public float jumpForce;
    private bool canJump;

    private void Start()
    {
    }

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        playerControls = new PlayerInputActions();

        playerControls.Player.Jump.performed += ctx => Jump();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Jump()
    {
        if (canJump)
        {
            player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }
}
