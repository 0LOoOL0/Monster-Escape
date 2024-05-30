using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CabinetPuzzleValidator : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas PuzzleCanvas;
    public TMP_InputField inputField;
    public TMP_Text statusText;
    public string correctAnswer = "4534";
    private bool isInteracting = true;
    public Button submitButton; // Declare the submit button

    void Start()
    {
       // Hook up the button click event
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteracting = true;
            Debug.Log("Player entered trigger zone");
            submitButton.onClick.AddListener(OnSubmitButtonClicked);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteracting = false;
            Debug.Log("Player exited trigger zone");
            // Reset the puzzle state here
            PuzzleCanvas.enabled = false;
            EPromptCanvas.enabled = true;
            // Optionally, reset the input field and status text
            inputField.text = "";
            statusText.text = "";
            submitButton.onClick.RemoveListener(OnSubmitButtonClicked);
        }
    }

    public void OnSubmitButtonClicked() // Method to handle button click
    {
        if (isInteracting && !PuzzleCanvas.enabled) // Ensure we're not trying to solve the puzzle if it's already active
        {
            PuzzleCanvas.enabled = true;
            EPromptCanvas.enabled = false;
            Debug.Log("Attempting to solve cabinet puzzle");
            ValidateInput();
        }
    }

    public void ValidateInput()
    {
        string input = inputField.text.Trim();
        if (input == correctAnswer)
        {
            Debug.Log("Correct Answer!");
            statusText.text = "Correct"; // Inform the player
            statusText.color = Color.green; // Change color to green for success
            isInteracting = false; // Set flag to false once the correct answer is validated
            Debug.Log("Puzzle solved, player can exit");
            submitButton.onClick.AddListener(OnSubmitButtonClicked);
        }
        else
        {
            Debug.Log("Incorrect Answer.");
            statusText.text = "Try Again."; // Show error message or hint
            statusText.color = Color.red; // Change color to red for incorrect answers
        }
    }
}
