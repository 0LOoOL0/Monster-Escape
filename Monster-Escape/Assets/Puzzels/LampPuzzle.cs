using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LampPuzzle : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas LampCanvas;
    public TMP_InputField LampInputField;
    public TMP_Text LampStatusText;
    public Button LampButton;
    public string correctCombination;
    private bool puzzleSolved = false; // Flag to prevent multiple submissions

    private void Start()
    {
        LampButton.onClick.AddListener(OnLampSubmitButtonClicked);
        LampCanvas.enabled = false; // Make sure the LampCanvas is initially disabled
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
        EPromptCanvas.enabled = false;
        LampCanvas.enabled = true;
        LampInputField.text = "";
        LampInputField.Select();
        LampInputField.ActivateInputField();
    }

    private void EndInteraction()
    {
        EPromptCanvas.enabled = true;
        LampCanvas.enabled = false;
        LampInputField.text = "";
    }

    private void OnLampSubmitButtonClicked()
    {
        ValidateCombination(LampInputField.text);
    }

    private void ValidateCombination(string input)
    {
        if (input.Equals(correctCombination, System.StringComparison.OrdinalIgnoreCase) && input != "")
        {
            LampStatusText.text = "Correct Combination!";
            LampStatusText.color = Color.green;
            puzzleSolved = true; // Mark the puzzle as solved
            HomePuzzleManager.Instance.isLampPuzzleSolved = true;
            HomePuzzleManager.Instance.CheckPuzzlesSolved();
            StartCoroutine(ExitPuzzle());
        }
        else
        {
            LampStatusText.text = "Try Again. Incorrect Combination.";
            LampStatusText.color = Color.red;
        }
    }

    private IEnumerator ExitPuzzle()
    {
        yield return new WaitForSeconds(2f);
        EndInteraction();
    }
}
