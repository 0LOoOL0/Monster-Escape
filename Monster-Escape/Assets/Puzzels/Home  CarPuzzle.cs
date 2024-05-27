using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {
        Debug.Log("Update called");
        if (isInteracting && Input.GetKeyDown(KeyCode.E))
        {
            if (!PuzzleCanvas.enabled) // Only attempt to solve the puzzle if the canvas is disabled
            {
                PuzzleCanvas.enabled = true;
                EPromptCanvas.enabled = false;
                Debug.Log("Attempting to solve car puzzle");
                SolvePuzzle(inputField.text);
            }
            else // If the puzzle is enabled, assume the player wants to exit
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

    public void SolvePuzzle(string input)
    {
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
