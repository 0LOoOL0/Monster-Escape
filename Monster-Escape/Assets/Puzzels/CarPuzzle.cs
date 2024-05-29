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
        // Initialize the button click listener outside of the trigger zones to avoid unnecessary checks
        submitButton.onClick.AddListener(OnSubmitButtonClicked);
    }

    void Update()
    {
        Debug.Log("Update called");
        if (isInteracting)
        {
            if (Input.GetKeyDown(KeyCode.Return)) // Keep the key press handling for exiting the puzzle
            {
                ExitPuzzle();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteracting = true;
            Debug.Log("Player entered trigger zone");
            // Dynamically add the button click listener when entering the trigger zone
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
            // Dynamically remove the button click listener when exiting the trigger zone
            submitButton.onClick.RemoveListener(OnSubmitButtonClicked);
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

    void ExitPuzzle()
    {
        // Logic to exit the puzzle area
        // This could involve disabling the puzzle canvas and enabling the prompt canvas
        PuzzleCanvas.enabled = false;
        EPromptCanvas.enabled = true;
        Debug.Log("Exiting puzzle");
    }
}
