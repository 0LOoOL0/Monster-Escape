using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TelephonePuzzleInteraction : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas TelephoneCanvas;
    public TMP_InputField TelephoneInputField;
    public TMP_Text TelephoneStatusText;
    public Button TelephoneButton;

    public string correctCode;
    private bool isInteracting = false;
    private bool puzzleSolved = false; // Flag to prevent multiple submissions

    private void Start()
    {
        // Hook up the button click event
        TelephoneButton.onClick.AddListener(OnTelephoneSubmitButtonClicked);
    }

    public void StartTelephoneInteraction()
    {
        if (!puzzleSolved) // Only start interaction if the puzzle isn't solved
        {
            isInteracting = true;
            EPromptCanvas.enabled = false;
            TelephoneCanvas.enabled = true;
            TelephoneInputField.text = "";
            TelephoneInputField.Select();
            TelephoneInputField.ActivateInputField();
        }
    }

    public void EndTelephoneInteraction()
    {
        isInteracting = false;
        EPromptCanvas.enabled = true;
        TelephoneCanvas.enabled = false;
        TelephoneInputField.text = "";
    }

    public void SubmitTelephoneAnswer()
    {
        if (!puzzleSolved) // Only check the answer if the puzzle isn't solved
        {
            string input = TelephoneInputField.text.Trim(); // Trim any extra spaces
            Debug.Log("Input: " + input); // Debug log for input
            Debug.Log("Correct Code: " + correctCode); // Debug log for correct code

            if (input.Equals(correctCode, System.StringComparison.OrdinalIgnoreCase) && input != "")
            {
                Debug.Log("Telephone Unlocked!");
                TelephoneStatusText.text = "Correct Code!";
                TelephoneStatusText.color = Color.green;
                puzzleSolved = true; // Mark the puzzle as solved
                PuzzleManager.Instance.isTelephonePuzzleSolved = true;
                PuzzleManager.Instance.CheckPuzzlesSolved();
                StartCoroutine(ExitTelephonePuzzle());
            }
            else
            {
                Debug.Log("Incorrect Code.");
                TelephoneStatusText.text = input != "" ? "Try Again. Incorrect Code." : "";
                TelephoneStatusText.color = Color.red;
            }
        }
    }

    private IEnumerator ExitTelephonePuzzle()
    {
        yield return new WaitForSeconds(2f); // Wait for a moment before exiting
        EndTelephoneInteraction();
    }

    private void OnTelephoneSubmitButtonClicked()
    {
        SubmitTelephoneAnswer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartTelephoneInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndTelephoneInteraction();
        }
    }
}
