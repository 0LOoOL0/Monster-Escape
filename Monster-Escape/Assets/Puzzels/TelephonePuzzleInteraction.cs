using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TelephonePuzzleInteraction : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas PuzzleCanvas;
    public TMP_InputField inputField;
    public TMP_Text statusText;
    private string correctCode = "379412"; // Unique correct code for the telephone puzzle
    private bool isInteracting = false;
    public Button submitButton; // Public Button field

    void Start()
    {
        // Hook up the button click event
        submitButton.onClick.AddListener(OnSubmitButtonClicked);
    }

    public void StartInteraction()
    {
        isInteracting = true;
        EPromptCanvas.enabled = false;
        PuzzleCanvas.enabled = true;
        inputField.text = "";
        inputField.Select();
        inputField.ActivateInputField();
    }

    public void EndInteraction()
    {
        isInteracting = false;
        EPromptCanvas.enabled = true;
        PuzzleCanvas.enabled = false;
        inputField.text = "";
    }

    public void SubmitAnswer()
    {
        string input = inputField.text;
        if (input == correctCode && input != "")
        {
            Debug.Log("Telephone Unlocked!");
            statusText.text = "Correct Code!";
            statusText.color = Color.green;
            StartCoroutine(ExitPuzzle());
        }
        else
        {
            Debug.Log("Incorrect Code.");
            statusText.text = input != "" ? "Try Again. Incorrect Code." : "";
            statusText.color = Color.red;
        }
    }

    IEnumerator ExitPuzzle()
    {
        yield return new WaitForSeconds(2f); // Wait for a moment before exiting
        EndInteraction();
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

    private void Update()
    {
        if (isInteracting && Input.GetKeyDown(KeyCode.Return))
        {
            SubmitAnswer();
        }
    }

    // Call this method when the Submit button is clicked
    public void OnSubmitButtonClicked()
    {
        SubmitAnswer();
    }
}
