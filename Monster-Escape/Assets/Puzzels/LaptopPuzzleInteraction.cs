using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LaptopPuzzleInteraction : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas LaptopCanvas; // Changed PuzzleCanvas to LaptopCanvas
    public TMP_InputField LaptopInputField; // Changed inputField to LaptopInputField
    public TMP_Text LaptopStatusText; // Changed statusText to LaptopStatusText
    public Button LaptopButton; // Changed submitButton to LaptopButton

    private string correctCode = "3575"; // Unique correct code for the laptop puzzle
    private bool isInteracting = false;

    private void Start()
    {
        // Hook up the button click event
        LaptopButton.onClick.AddListener(OnSubmitButtonClicked);
    }

    public void StartInteraction()
    {
        isInteracting = true;
        EPromptCanvas.enabled = false;
        LaptopCanvas.enabled = true; // Changed PuzzleCanvas to LaptopCanvas
        LaptopInputField.text = ""; // Changed inputField to LaptopInputField
        LaptopInputField.Select(); // Changed inputField to LaptopInputField
        LaptopInputField.ActivateInputField(); // Changed inputField to LaptopInputField
    }

    public void EndInteraction()
    {
        isInteracting = false;
        EPromptCanvas.enabled = true;
        LaptopCanvas.enabled = false; // Changed PuzzleCanvas to LaptopCanvas
        LaptopInputField.text = ""; // Changed inputField to LaptopInputField
    }

    public void SubmitAnswer()
    {
        string input = LaptopInputField.text; // Changed inputField to LaptopInputField
        if (input == correctCode && input != "")
        {
            Debug.Log("Laptop Unlocked!");
            LaptopStatusText.text = "Correct Code!"; // Changed statusText to LaptopStatusText
            LaptopStatusText.color = Color.green; // Changed statusText to LaptopStatusText
            StartCoroutine(ExitPuzzle());
        }
        else
        {
            Debug.Log("Incorrect Code.");
            LaptopStatusText.text = input != "" ? "Try Again. Incorrect Code." : ""; // Changed statusText to LaptopStatusText
            LaptopStatusText.color = Color.red; // Changed statusText to LaptopStatusText
        }
    }

    private IEnumerator ExitPuzzle()
    {
        yield return new WaitForSeconds(2f); // Wait for a moment before exiting
        EndInteraction();
    }

    private void OnSubmitButtonClicked()
    {
        SubmitAnswer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndInteraction();
        }
    }
}
