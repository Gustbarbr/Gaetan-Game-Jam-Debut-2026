using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public GameObject player;
    public PlayerAttributes playerAttributes;

    // Reference one specificaction present in the Input Actions
    [SerializeField] private InputActionReference playerAttack;
    [SerializeField] private InputActionAsset playerInputActions;
    private InputAction lookAction;

    [Header("Prefabs")]
    [SerializeField] private GameObject mistArrowPrefab;
    [SerializeField] private Vector3 prefabSpawnPosition;
    [SerializeField] private float prefabMoveSpeed;

    [Header("Mouse")]
    private Camera mainCamera;
    private Vector2 mousePosition;

    private void Update()
    {
        prefabSpawnPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

    private void Awake()
    {
        mainCamera = Camera.main;

        var playerMap = playerInputActions.FindActionMap("Player");
        lookAction = playerMap.FindAction("Look");

        lookAction.performed += OnLook;
        lookAction.canceled += OnLook;
    }

    private void OnEnable()
    {
        playerAttack.action.performed += OnActionPerformed;
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerAttack.action.performed -= OnActionPerformed;
        playerInputActions.Disable();
        lookAction.performed -= OnLook;
        lookAction.canceled -= OnLook;
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }

    private void OnActionPerformed(InputAction.CallbackContext context)
    {
        // Check which button triggered the action
        string controlPath = context.control.path;

        // Get the name of the button
        //Debug.Log("Action performed by: " + controlPath);

        if (controlPath.Contains("/Mouse/leftButton") && playerAttributes.manaCurrentValue >= 5)
        {
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, -mainCamera.transform.position.z));
            Vector3 direction = (mouseWorldPosition - prefabSpawnPosition).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            var prefabSpawnRotation = Quaternion.Euler(0f, 0f, angle);

            GameObject mistArrowPrefabClone = Instantiate(mistArrowPrefab, prefabSpawnPosition, prefabSpawnRotation);

            Rigidbody2D rb = mistArrowPrefabClone.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * prefabMoveSpeed;

            playerAttributes.manaCurrentValue -= 5f;
        }
    }
}
