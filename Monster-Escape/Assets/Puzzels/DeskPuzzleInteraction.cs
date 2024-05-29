using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeskPuzzleInteraction : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas DeskCanvas; // Changed PuzzleCanvas to DeskCanvas
    public TMP_InputField DeskInputField; // Changed inputField to DeskInputField
    public TMP_Text DeskStatusText; // Changed statusText to DeskStatusText
    public Button DeskButton; // Changed submitButton to DeskButton

    private string correctCode = "123456"; // Unique correct code for the desk puzzle
    private bool isInteracting = false;

    private void Start()
    {
        // Hook up the button click event
        DeskButton.onClick.AddListener(OnSubmitButtonClicked);
    }

    public void StartInteraction()
    {
        isInteracting = true;
        EPromptCanvas.enabled = false;
        DeskCanvas.enabled = true; // Changed PuzzleCanvas to DeskCanvas
        DeskInputField.text = ""; // Changed inputField to DeskInputField
        DeskInputField.Select(); // Changed inputField to DeskInputField
        DeskInputField.ActivateInputField(); // Changed inputField to DeskInputField
    }

    public void EndInteraction()
    {
        isInteracting = false;
        EPromptCanvas.enabled = true;
        DeskCanvas.enabled = false; // Changed PuzzleCanvas to DeskCanvas
        DeskInputField.text = ""; // Changed inputField to DeskInputField
    }

    public void SubmitAnswer()
    {
        string input = DeskInputField.text; // Changed inputField to DeskInputField
        if (input == correctCode && input != "")
        {
            Debug.Log("Desk Unlocked!");
            DeskStatusText.text = "Correct Code!"; // Changed statusText to DeskStatusText
            DeskStatusText.color = Color.green; // Changed statusText to DeskStatusText
            StartCoroutine(ExitPuzzle());
        }
        else
        {
            Debug.Log("Incorrect Code.");
            DeskStatusText.text = input != "" ? "Try Again. Incorrect Code." : ""; // Changed statusText to DeskStatusText
            DeskStatusText.color = Color.red; // Changed statusText to DeskStatusText
        }
    }

    private IEnumerator ExitPuzzle()
    {
        yield return new WaitForSeconds(2f); // Wait for a moment before exiting
        EndInteraction();
    }

    private void OnSubmitButtonClicked()
    {
        SubmitAnswer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndInteraction();
        }
    }
}
