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
        if (isInteracting)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PuzzleCanvas.enabled = true;
                EPromptCanvas.enabled = false;
                Debug.Log("Attempting to solve car puzzle");
                StartCoroutine(SolvePuzzle());
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

    IEnumerator SolvePuzzle()
    {
        yield return new WaitForSeconds(1f); // Wait for a second to simulate the puzzle-solving process
        if (inputField.text.ToUpper() == correctAnswer.ToUpper())
        {
            Debug.Log("Car Puzzle Solved!");
            statusText.text = "Car Puzzle Solved"; // Inform the player
            statusText.color = Color.green; // Change color to green for success
            isInteracting = false; // Set flag to false once the correct answer is entered
            Debug.Log("Puzzle solved, player can exit");
        }
        else
        {
            Debug.Log("Incorrect Answer.");
            statusText.text = "Try Again. Incorrect Answer."; // Show error message or hint
            statusText.color = Color.red; // Change color to red for incorrect answers
        }
    }
}
