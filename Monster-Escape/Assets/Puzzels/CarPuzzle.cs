using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarPuzzle : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas CarCanvas; // Changed DeskCanvas to CarCanvas
    public TMP_InputField CarInputField; // Changed DeskInputField to CarInputField
    public TMP_Text CarStatusText; // Changed DeskStatusText to CarStatusText
    public Button CarButton; // Changed DeskButton to CarButton

    public string correctAnswer = "YOU CAN'T RUN USING THIS CAR";
    private bool isInteracting = false;

    private void Start()
    {
        // Hook up the button click event
        CarButton.onClick.AddListener(OnCarSubmitButtonClicked);
    }

    public void StartInteraction()
    {
        isInteracting = true;
        EPromptCanvas.enabled = false;
        CarCanvas.enabled = true; // Changed DeskCanvas to CarCanvas
        CarInputField.text = ""; // Changed DeskInputField to CarInputField
        CarInputField.Select(); // Changed DeskInputField to CarInputField
        CarInputField.ActivateInputField(); // Changed DeskInputField to CarInputField
    }

    public void EndInteraction()
    {
        isInteracting = false;
        EPromptCanvas.enabled = true;
        CarCanvas.enabled = false; // Changed DeskCanvas to CarCanvas
        CarInputField.text = ""; // Changed DeskInputField to CarInputField
    }

    public void SubmitAnswer()
    {
        string input = CarInputField.text; // Changed DeskInputField to CarInputField
        if (input.ToUpper() == correctAnswer.ToUpper() && input != "")
        {
            Debug.Log("Car Puzzle Solved!");
            CarStatusText.text = "Car Puzzle Solved"; // Changed DeskStatusText to CarStatusText
            CarStatusText.color = Color.green; // Changed DeskStatusText to CarStatusText
            StartCoroutine(ExitPuzzle());
        }
        else
        {
            Debug.Log("Incorrect Answer.");
            CarStatusText.text = input != "" ? "Try Again. Incorrect Answer." : ""; // Changed DeskStatusText to CarStatusText
            CarStatusText.color = Color.red; // Changed DeskStatusText to CarStatusText
        }
    }

    private IEnumerator ExitPuzzle()
    {
        yield return new WaitForSeconds(2f); // Wait for a moment before exiting
        EndInteraction();
    }

    private void OnCarSubmitButtonClicked()
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
