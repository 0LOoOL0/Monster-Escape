using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarPuzzle : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas PuzzleCanvas;
    public TMP_InputField inputField;
    public TMP_Text statusText;
    public string correctAnswer = "YOU CAN'T RUN USING THIS CAR";
    private bool isInteracting = true;
    public Button submitButton; // Declare the submit button

    void Start()
    {
        submitButton.onClick.AddListener(OnSubmitButtonClicked); // Hook up the button click event
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteracting = true;
            Debug.Log("Player entered trigger zone");
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
        }
    }

    public void OnSubmitButtonClicked() // Method to handle button click
    {
        if (isInteracting && !PuzzleCanvas.enabled) // Ensure we're not trying to solve the puzzle if it's already active
        {
            PuzzleCanvas.enabled = true;
            EPromptCanvas.enabled = false;
            Debug.Log("Attempting to solve car puzzle");
            SolvePuzzle(inputField.text);
        }
    }

    public void SolvePuzzle(string input)
    {
        inputField.text = "";
        if (input.ToUpper() == correctAnswer.ToUpper())
        {
            Debug.Log("Car Puzzle Solved!");
            statusText.text = "Car Puzzle Solved"; // Inform the player
            statusText.color = Color.green; // Change color to green for success
            isInteracting = false; // Set flag to false once the correct answer is entered
            Debug.Log("Puzzle solved, player can exit");
            // Wait for player to press E to exit
            StartCoroutine(WaitAndExit());
        }
        else
        {
            Debug.Log("Incorrect Answer.");
            statusText.text = "Try Again. Incorrect Answer."; // Show error message or hint
            statusText.color = Color.red; // Change color to red for incorrect answers
        }
    }

    IEnumerator WaitAndExit()
    {
        yield return new WaitForSeconds(0.5f); // Wait for half a second
        isInteracting = true; // Enable interaction again
    }
}
