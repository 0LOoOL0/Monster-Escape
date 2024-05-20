using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneLock : MonoBehaviour
{
    public InputField passwordInput; // Assign the input field in the Inspector
    public string correctPassword = "EMPTY"; // Set the correct password

    void Update()
    {
        if (passwordInput.text == correctPassword)
        {
            Debug.Log("Phone Unlocked!");
            // Unlock the phone functionality here
        }
    }
}