using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public GameObject player;
    public PlayerAttributes playerAttributes;

    // Reference one specificaction present in the Input Actions
    [SerializeField] private InputActionReference primaryAttack;
    [SerializeField] private InputActionReference secondaryAttack;
    [SerializeField] private InputActionAsset playerInputActions;
    private InputAction lookAction;

    [Header("Prefabs")]
    [SerializeField] private GameObject mistArrowPrefab;
    [SerializeField] private GameObject mistDescentPrefab;
    [SerializeField] private Vector3 prefabSpawnPosition;
    [SerializeField] private float prefabMoveSpeed;

    [Header("Unlock Spells")]
    public bool mistDescentUnlocked = false;

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
        primaryAttack.action.performed += OnPrimaryAttack;
        secondaryAttack.action.performed += OnSecondaryAttack;
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        primaryAttack.action.performed -= OnPrimaryAttack;
        secondaryAttack.action.performed -= OnSecondaryAttack;
        playerInputActions.Disable();
        lookAction.performed -= OnLook;
        lookAction.canceled -= OnLook;
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }

    private void OnPrimaryAttack(InputAction.CallbackContext context)
    {
        if (playerAttributes.manaCurrentValue < 5) return;

        Vector3 mouseWorldPosition =
            mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, -mainCamera.transform.position.z));

        Vector3 direction = (mouseWorldPosition - prefabSpawnPosition).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        GameObject arrow = Instantiate(mistArrowPrefab, prefabSpawnPosition, rotation);
        arrow.GetComponent<Rigidbody2D>().linearVelocity = direction * prefabMoveSpeed;

        playerAttributes.manaCurrentValue -= 5f;
    }

    private void OnSecondaryAttack(InputAction.CallbackContext context)
    {
        if (!mistDescentUnlocked) return;
        if (playerAttributes.manaCurrentValue < 5) return;

        Vector3 mouseWorldPosition =
            mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, -mainCamera.transform.position.z));

        Instantiate(mistDescentPrefab, mouseWorldPosition, Quaternion.identity);

        playerAttributes.manaCurrentValue -= 5f;
    }
}
