using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathPuzzleValidator : MonoBehaviour
{
    public InputField inputField; // Assign this in the inspector
    public string correctAnswer = "3575";

    public void ValidateInput()
    {
        string input = inputField.text.Trim();
        if (input == correctAnswer)
        {
            Debug.Log("Correct Answer!");
            // Unlock the next part of the game
        }
        else
        {
            Debug.Log("Incorrect Answer.");
            // Show error message or hint
        }
    }
}

