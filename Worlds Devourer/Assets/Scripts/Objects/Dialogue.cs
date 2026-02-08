using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBackground;

    [SerializeField] private InputActionReference interact;

    [TextArea(2, 5)]
    public string[] lines;

    private int currentLine = 0;
    private bool isDialogueActive = false;

    private void OnEnable()
    {
        interact.action.performed += OnInteract;
        interact.action.Enable();
    }

    private void OnDisable()
    {
        interact.action.performed -= OnInteract;
        interact.action.Disable();
    }

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "Main")
        {
            PlayerMovement playerMovement = Object.FindAnyObjectByType<PlayerMovement>();
            FoodTimer foodTimer = Object.FindAnyObjectByType<FoodTimer>();

            playerMovement.enabled = false;
            foodTimer.foodTimerEnabled = false;
        }

        StartDialogue();
    }

    public void StartDialogue()
    {
        if (lines.Length == 0) return;

        isDialogueActive = true;
        currentLine = 0;

        dialogueText.gameObject.SetActive(true);
        dialogueText.text = lines[currentLine];
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (!isDialogueActive) return;

        currentLine++;

        if (currentLine < lines.Length)
        {
            dialogueText.text = lines[currentLine];
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        dialogueText.text = "";
        dialogueText.gameObject.SetActive(false);
        dialogueBackground.gameObject.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Main")
        {
            PlayerMovement playerMovement = Object.FindAnyObjectByType<PlayerMovement>();
            FoodTimer foodTimer = Object.FindAnyObjectByType<FoodTimer>();

            playerMovement.enabled = true;
            foodTimer.foodTimerEnabled = true;
        }

        if (scene.name == "Death" || scene.name == "Victory")
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
