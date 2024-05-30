using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LaptopPuzzleInteraction : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas LaptopCanvas;
    public TMP_InputField LaptopInputField;
    public TMP_Text LaptopStatusText;
    public Button LaptopButton;

    public string correctCode;
    private bool isInteracting = false;
    private bool puzzleSolved = false; // Flag to prevent multiple submissions

    private void Start()
    {
        // Hook up the button click event
        LaptopButton.onClick.AddListener(OnLaptopSubmitButtonClicked);
    }

    public void StartLaptopInteraction()
    {
        if (!puzzleSolved) // Only start interaction if the puzzle isn't solved
        {
            isInteracting = true;
            EPromptCanvas.enabled = false;
            LaptopCanvas.enabled = true;
            LaptopInputField.text = "";
            LaptopInputField.Select();
            LaptopInputField.ActivateInputField();
        }
    }

    public void EndLaptopInteraction()
    {
        isInteracting = false;
        EPromptCanvas.enabled = true;
        LaptopCanvas.enabled = false;
        LaptopInputField.text = "";
    }

    public void SubmitLaptopAnswer()
    {
        if (!puzzleSolved) // Only check the answer if the puzzle isn't solved
        {
            string input = LaptopInputField.text.Trim(); // Trim any extra spaces
            Debug.Log("Input: " + input); // Debug log for input
            Debug.Log("Correct Code: " + correctCode); // Debug log for correct code

            if (input.Equals(correctCode, System.StringComparison.OrdinalIgnoreCase) && input != "")
            {
                Debug.Log("Laptop Unlocked!");
                LaptopStatusText.text = "Correct Code!";
                LaptopStatusText.color = Color.green;
                puzzleSolved = true; // Mark the puzzle as solved
                PuzzleManager.Instance.isLaptopPuzzleSolved = true;
                PuzzleManager.Instance.CheckPuzzlesSolved();
                StartCoroutine(ExitLaptopPuzzle());
            }
            else
            {
                Debug.Log("Incorrect Code.");
                LaptopStatusText.text = input != "" ? "Try Again. Incorrect Code." : "";
                LaptopStatusText.color = Color.red;
            }
        }
    }

    private IEnumerator ExitLaptopPuzzle()
    {
        yield return new WaitForSeconds(2f); // Wait for a moment before exiting
        EndLaptopInteraction();
    }

    private void OnLaptopSubmitButtonClicked()
    {
        SubmitLaptopAnswer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartLaptopInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !puzzleSolved)
        {
            EndLaptopInteraction();
        }
    }
}
