using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LaptopPuzzleInteraction : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas PuzzleCanvas;
    public TMP_InputField inputField;
    public TMP_Text statusText;
    public string correctAnswer = "3575";
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
                Debug.Log("Attempting to solve puzzle");
                CheckAnswer(inputField.text);
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
        if (input == correctAnswer)
        {
            Debug.Log("Puzzle Solved!");
            statusText.text = "Correct!";
            statusText.color = Color.green;
            // Puzzle solved, player can exit
            isInteracting = false;
            Debug.Log("Puzzle solved, player can exit");
        }
        else
        {
            Debug.Log("Incorrect Answer.");
            statusText.text = "Try Again. Incorrect Answer.";
            statusText.color = Color.red;
        }
    }
}
