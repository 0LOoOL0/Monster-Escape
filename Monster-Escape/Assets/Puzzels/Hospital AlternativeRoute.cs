using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeRoute : MonoBehaviour
{
    public GameObject alternativeExit; // Assign this in the inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            alternativeExit.SetActive(true);
            Debug.Log("Alternative Exit Activated");
        }
    }
}

