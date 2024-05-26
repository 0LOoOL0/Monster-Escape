using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeskPuzzleInteraction : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas PuzzleCanvas;
    public TMP_InputField inputField;
    public TMP_Text statusText;
    public string correctCode = "123456";
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
                Debug.Log("Attempting to solve puzzle");
                CheckAnswer(inputField.text);
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

    public void CheckAnswer(string input)
    {
        inputField.text = "";
        if (input == correctCode)
        {
            Debug.Log("Desk Unlocked!");
            statusText.text = "Correct Code"; // Display success message
            statusText.color = Color.green; // Change color to green for success
            // Puzzle solved, player can exit
            isInteracting = false; // Prevents immediate re-entry
            Debug.Log("Puzzle solved, player can exit");
            // Wait for player to press E to exit
            StartCoroutine(WaitAndExit());
        }
        else
        {
            Debug.Log("Incorrect Code.");
            statusText.text = "Try Again. Incorrect Code."; // Display failure message
            statusText.color = Color.red; // Change color to red for failure
            // Keep the puzzle active, allow player to try again or exit
            isInteracting = true; // Ensure interaction remains possible
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
