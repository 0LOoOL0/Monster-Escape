using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MathPuzzleValidator : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas PuzzleCanvas;
    public TMP_InputField inputField;
    public TMP_Text statusText;
    public string correctAnswer = "4534";
    private bool isInteracting = true;
    public Button submitButton; // Added this line

    void Start()
    {
        // Hook up the button click event
       
    }

    void Update()
    {
        Debug.Log("Update called");
        if (isInteracting)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PuzzleCanvas.enabled = true;
                EPromptCanvas.enabled = false;
                Debug.Log("Attempting to solve math puzzle");
                OnSubmitButtonClicked(); // Call the method hooked to the button click
            }
        }
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

    public void OnSubmitButtonClicked()
    {
        if (isInteracting && PuzzleCanvas.enabled)
        {
            CheckAnswer(inputField.text);
        }
    }

    public void CheckAnswer(string input)
    {
        inputField.text = ""; // Clear the input field after checking the answer
        if (input == correctAnswer)
        {
            Debug.Log("Correct Answer!");
            statusText.text = "Correct"; // Inform the player
            statusText.color = Color.green; // Change color to green for success
            isInteracting = false; // Set flag to false once the correct answer is validated
            Debug.Log("Puzzle solved, player can exit");
            // Force Mesh Update to apply the color change immediately
            statusText.ForceMeshUpdate();
            // Hide the status text after 3 seconds and disable the PuzzleCanvas if correct
            StartCoroutine(HideStatusText(true));
            submitButton.onClick.RemoveListener(OnSubmitButtonClicked);
        }
        else
        {
            Debug.Log("Incorrect Answer.");
            statusText.text = "Try Again."; // Show error message or hint
            statusText.color = Color.red; // Change color to red for incorrect answers
            // Force Mesh Update to apply the color change immediately
            statusText.ForceMeshUpdate();
            // Hide the status text after 3 seconds
            StartCoroutine(HideStatusText(false));
        }
    }

    IEnumerator HideStatusText(bool correct)
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        statusText.text = ""; // Clear the status text
        if (correct)
        {
            PuzzleCanvas.enabled = false; // Disable the PuzzleCanvas if the answer is correct
            EPromptCanvas.enabled = true; // Enable the EPromptCanvas
        }
    }
}
