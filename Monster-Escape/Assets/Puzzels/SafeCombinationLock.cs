using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SafeCombinationLock : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas PuzzleCanvas;
    public TMP_InputField UserAnswer_inputField;
    public TMP_Text UserAnswer_text;
    public string correctCombination = "1234";
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
            UserAnswer_inputField.text = "";
            UserAnswer_text.text = "";
            submitButton.onClick.RemoveListener(OnSubmitButtonClicked);
        }
    }

    public void OnSubmitButtonClicked() // Method to handle button click
    {
        if (isInteracting && !PuzzleCanvas.enabled) // Ensure we're not trying to solve the puzzle if it's already active
        {
            PuzzleCanvas.enabled = true;
            EPromptCanvas.enabled = false;
            Debug.Log("Attempting to solve safe combination lock");
            ValidateCombination(UserAnswer_inputField.text);
        }
    }

    public void ValidateCombination(string input)
    {
        if (input == correctCombination)
        {
            Debug.Log("Lamp Open");
            UserAnswer_text.text = "Correct!";
            UserAnswer_text.color = Color.green; // Change color to green for correct answers
            isInteracting = false; // Set flag to false once the correct combination is entered
            Debug.Log("Puzzle solved, player can exit");
        }
        else
        {
            Debug.Log("Incorrect Combination.");
            UserAnswer_text.text = "Try again.";
            UserAnswer_text.color = Color.red; // Change color to red for incorrect answers
        }
    }
}
