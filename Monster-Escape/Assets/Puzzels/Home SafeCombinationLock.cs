using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {
        Debug.Log("Update called");
        if (isInteracting)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PuzzleCanvas.enabled = true;
                EPromptCanvas.enabled = false;
                Debug.Log("Attempting to solve safe combination lock");
                ValidateCombination();
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
            UserAnswer_inputField.text = "";
            UserAnswer_text.text = "";
        }
    }

    public void ValidateCombination()
    {
        string input = UserAnswer_inputField.text.Trim();
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
