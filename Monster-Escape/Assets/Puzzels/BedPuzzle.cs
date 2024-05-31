using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Add this line

public class BedPuzzle : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas BedCanvas;
    public TMP_InputField BedInputField;
    public TMP_Text BedStatusText;
    public Button BedButton;
    public string correctAnswer;
    private bool isInteracting = false;

    private void Start()
    {
        // Check for null references and log which ones are missing
        if (EPromptCanvas == null)
        {
            Debug.LogError("EPromptCanvas is not assigned in the Inspector.");
        }
        else
        {
            Debug.Log("EPromptCanvas is assigned.");
        }

        if (BedCanvas == null)
        {
            Debug.LogError("BedCanvas is not assigned in the Inspector.");
        }
        else
        {
            Debug.Log("BedCanvas is assigned.");
        }

        if (BedInputField == null)
        {
            Debug.LogError("BedInputField is not assigned in the Inspector.");
        }
        else
        {
            Debug.Log("BedInputField is assigned.");
        }

        if (BedStatusText == null)
        {
            Debug.LogError("BedStatusText is not assigned in the Inspector.");
        }
        else
        {
            Debug.Log("BedStatusText is assigned.");
        }

        if (BedButton == null)
        {
            Debug.LogError("BedButton is not assigned in the Inspector.");
        }
        else
        {
            Debug.Log("BedButton is assigned.");
        }

        if (EPromptCanvas == null || BedCanvas == null || BedInputField == null || BedStatusText == null || BedButton == null)
        {
            Debug.LogError("One or more UI elements are missing. Please assign them in the Inspector.");
            return;
        }

        // Hook up the button click event
        BedButton.onClick.AddListener(OnBedSubmitButtonClicked);
        BedCanvas.enabled = false; // Make sure the BedCanvas is initially disabled
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone.");
            StartInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit called with: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger zone.");
            EndInteraction();
        }
    }

    public void StartInteraction()
    {
        Debug.Log("StartInteraction called.");
        isInteracting = true;
        EPromptCanvas.enabled = false;
        BedCanvas.enabled = true;
        BedInputField.text = "";
        BedInputField.Select();
        BedInputField.ActivateInputField();
    }

    public void EndInteraction()
    {
        Debug.Log("EndInteraction called.");
        isInteracting = false;
        EPromptCanvas.enabled = true;
        BedCanvas.enabled = false;
        BedInputField.text = "";
    }

    public void SubmitAnswer()
    {
        Debug.Log("SubmitAnswer called.");
        string input = BedInputField.text;
        if (input.ToUpper() == correctAnswer.ToUpper() && input != "")
        {
            Debug.Log("Bed Puzzle Solved!");
            BedStatusText.text = "Bed Puzzle Solved";
            BedStatusText.color = Color.green;
            StartCoroutine(ExitPuzzle());
        }
        else
        {
            Debug.Log("Incorrect Answer.");
            BedStatusText.text = input != "" ? "Try Again. Incorrect Answer." : "";
            BedStatusText.color = Color.red;
        }
    }

    private IEnumerator ExitPuzzle()
    {
        yield return new WaitForSeconds(2f);
        EndInteraction();
        LoadNextScene(); // Load the next scene after the puzzle is solved
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("ScreenSchool"); // Go to the next scene
    }

    private void OnBedSubmitButtonClicked()
    {
        SubmitAnswer();
    }
}
