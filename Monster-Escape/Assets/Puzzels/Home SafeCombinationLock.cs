using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeCombinationLock : MonoBehaviour
{
    public InputField inputField; // Assign this in the inspector
    public string correctCombination = "1234";
    public GameObject safe; // Assign this in the inspector

    public void ValidateCombination()
    {
        string input = inputField.text.Trim();
        if (input == correctCombination)
        {
            Debug.Log("Safe Unlocked");
            safe.SetActive(false); // Simulate unlocking the safe
        }
        else
        {
            Debug.Log("Incorrect Combination.");
            // Show error message or hint
        }
    }
}
