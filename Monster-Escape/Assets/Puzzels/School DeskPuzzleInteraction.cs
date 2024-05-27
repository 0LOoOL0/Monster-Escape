using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeskPuzzleInteraction : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas PuzzleCanvas;
    public TMP_InputField inputField;
    public TMP_Text statusText;
    public string correctCode = "123456";
    private bool isInteracting = true;
    public Button submitButton; // Add this line

    void Start()
    {
        submitButton.onClick.AddListener(OnSubmitButtonClicked); // Hook up the button click event
    }

    void Update()
    {
        Debug.Log("Update called");
        if (isInteracting && Input.GetKeyDown(KeyCode.E))
        {
            if (!PuzzleCanvas.enabled) // Only attempt to solve the puzzle if the canvas is disabled
            {
                PuzzleCanvas.enabled = true;
                EPromptCanvas.enabled = false;
                Debug.Log("PuzzleCanvas enabled, EPromptCanvas disabled.");
            }
            else // If the puzzle is enabled, assume the player wants to exit
            {
                ExitPuzzle();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteracting = true;
            Debug.Log("Player entered trigger zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteracting = false;
            Debug.Log("Player exited trigger zone");
            // Reset the puzzle state here
            PuzzleCanvas.enabled = false;
            EPromptCanvas.enabled = true;
            // Optionally, reset the input field and status text
            inputField.text = "";
            statusText.text = "";
            Debug.Log("PuzzleCanvas disabled, EPromptCanvas enabled.");
        }
    }

    public void OnSubmitButtonClicked() // Add this method
    {
        if (isInteracting && PuzzleCanvas.enabled)
        {
            CheckAnswer(inputField.text);
        }
    }

    public void CheckAnswer(string input)
    {
        inputField.text = ""; // Clear the input field after checking the answer
        if (input == correctCode)
        {
            Debug.Log("Desk Unlocked!");
            statusText.text = "Correct Code"; // Display "Correct Code!" if the answer is correct
            statusText.color = Color.green; // Change the text color to green for correct answers
            isInteracting = false; // Prevents immediate re-entry
            Debug.Log("Puzzle solved, player can exit");
            // Force Mesh Update to apply the color change immediately
            statusText.ForceMeshUpdate();
            // Hide the status text after 3 seconds and disable the PuzzleCanvas if correct
            StartCoroutine(HideStatusText(true));
        }
        else
        {
            Debug.Log("Incorrect Code.");
            statusText.text = "Try Again. Incorrect Code."; // Display "Try Again. Incorrect Code." if the answer is incorrect
            statusText.color = Color.red; // Change the text color to red for incorrect answers
            // Force Mesh Update to apply the color change immediately
            statusText.ForceMeshUpdate();
            // Hide the status text after 3 seconds
            StartCoroutine(HideStatusText(false));
        }
    }

    IEnumerator HideStatusText(bool correct)
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        statusText.text = ""; // Clear the status text
        if (correct)
        {
            PuzzleCanvas.enabled = false; // Disable the PuzzleCanvas if the answer is correct
            EPromptCanvas.enabled = true; // Enable the EPromptCanvas
        }
    }

    void ExitPuzzle()
    {
        // Logic to exit the puzzle area
        // This could involve disabling the puzzle canvas and enabling the prompt canvas
        PuzzleCanvas.enabled = false;
        EPromptCanvas.enabled = true;
        Debug.Log("Exiting puzzle");
    }
}








