using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas PuzzleCanvas;
    public TMP_InputField inputField;
    public TMP_Text statusText;
    public Button submitButton; // Public Button field

    private bool isInteracting = false;
    private string correctDeskCode = "123456"; // Correct code for the desk puzzle
    private string correctTelephoneCode = "379412"; // Correct code for the telephone puzzle
    private string correctLaptopCode = "3575"; // Correct code for the laptop puzzle

    public enum PuzzleType { None, Desk, Telephone, Laptop } // Make the enum public

    private PuzzleType currentPuzzleType = PuzzleType.None;

    private void Start()
    {
        submitButton.onClick.AddListener(OnSubmitButtonClicked);
    }

    public void StartInteraction(PuzzleType puzzleType)
    {
        isInteracting = true;
        EPromptCanvas.enabled = false;
        PuzzleCanvas.enabled = true;
        inputField.text = "";
        inputField.Select();
        inputField.ActivateInputField();

        currentPuzzleType = puzzleType;
    }

    public void EndInteraction()
    {
        isInteracting = false;
        EPromptCanvas.enabled = true;
        PuzzleCanvas.enabled = false;
        inputField.text = "";
        currentPuzzleType = PuzzleType.None;
    }

    public void SubmitAnswer()
    {
        string input = inputField.text;
        string correctCode = "";

        switch (currentPuzzleType)
        {
            case PuzzleType.Desk:
                correctCode = correctDeskCode;
                break;
            case PuzzleType.Telephone:
                correctCode = correctTelephoneCode;
                break;
            case PuzzleType.Laptop:
                correctCode = correctLaptopCode;
                break;
            default:
                Debug.LogWarning("No puzzle type selected!");
                break;
        }

        if (input == correctCode && input != "")
        {
            Debug.Log(currentPuzzleType.ToString() + " Unlocked!");
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
            string gameObjectName = gameObject.name;

            if (gameObjectName.Contains("Desk"))
            {
                StartInteraction(PuzzleType.Desk);
            }
            else if (gameObjectName.Contains("Phone"))
            {
                StartInteraction(PuzzleType.Telephone);
            }
            else if (gameObjectName.Contains("Laptop"))
            {
                StartInteraction(PuzzleType.Laptop);
            }
            else
            {
                Debug.LogWarning("Unknown puzzle type!");
            }
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
