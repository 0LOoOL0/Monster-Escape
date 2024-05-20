using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSupportMachine : MonoBehaviour
{
    public InputField inputField; // Assign in Inspector
    public string correctCode = "12345";
    public bool isFixed = false;

    void Update()
    {
        if (isFixed)
        {
            if (inputField.text == correctCode)
            {
                Debug.Log("Life Support Fixed!");
                // Proceed to the next level or scene
            }
        }
    }
}
