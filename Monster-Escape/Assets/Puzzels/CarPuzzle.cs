using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarPuzzle : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas CarCanvas;
    public TMP_InputField CarInputField;
    public TMP_Text CarStatusText;
    public Button CarButton;
    public string correctAnswer;
    private bool isInteracting = false;
    private bool puzzleSolved = false; // Flag to prevent multiple submissions

    private void Start()
    {
        CarButton.onClick.AddListener(OnCarSubmitButtonClicked);
        CarCanvas.enabled = false; // Make sure the CarCanvas is initially disabled
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !puzzleSolved)
        {
            StartInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !puzzleSolved)
        {
            EndInteraction();
        }
    }

    private void StartInteraction()
    {
        isInteracting = true;
        EPromptCanvas.enabled = false;
        CarCanvas.enabled = true;
        CarInputField.text = "";
        CarInputField.Select();
        CarInputField.ActivateInputField();
    }

    private void EndInteraction()
    {
        isInteracting = false;
        EPromptCanvas.enabled = true;
        CarCanvas.enabled = false;
        CarInputField.text = "";
    }

    private void OnCarSubmitButtonClicked()
    {
        SubmitAnswer();
    }

    private void SubmitAnswer()
    {
        string input = CarInputField.text.Trim(); // Trim any extra spaces
        if (input.Equals(correctAnswer, System.StringComparison.OrdinalIgnoreCase) && input != "")
        {
            CarStatusText.text = "Car Puzzle Solved";
            CarStatusText.color = Color.green;
            puzzleSolved = true; // Mark the puzzle as solved
            HomePuzzleManager.Instance.isCarPuzzleSolved = true;
            HomePuzzleManager.Instance.CheckPuzzlesSolved();
            StartCoroutine(ExitPuzzle());
        }
        else
        {
            CarStatusText.text = input != "" ? "Try Again. Incorrect Answer." : "";
            CarStatusText.color = Color.red;
        }
    }

    private IEnumerator ExitPuzzle()
    {
        yield return new WaitForSeconds(2f);
        EndInteraction();
    }
}
