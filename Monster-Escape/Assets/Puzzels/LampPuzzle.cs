using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LampPuzzle : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas LampCanvas; // Changed CarCanvas to LampCanvas
    public TMP_InputField LampInputField; // Changed CarInputField to LampInputField
    public TMP_Text LampStatusText; // Changed CarStatusText to LampStatusText
    public Button LampButton; // Changed CarButton to LampButton

    public string correctCombination = "1234";

    private void Start()
    {
        LampButton.onClick.AddListener(OnLampSubmitButtonClicked);
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
        if (input == correctCombination)
        {
            Debug.Log("Lamp Open");
            LampStatusText.text = "Correct Combination!";
            LampStatusText.color = Color.green;
            Debug.Log("Puzzle solved, player can exit");
        }
        else
        {
            Debug.Log("Incorrect Combination.");
            LampStatusText.text = "Try again.";
            LampStatusText.color = Color.red;
        }
    }
}
