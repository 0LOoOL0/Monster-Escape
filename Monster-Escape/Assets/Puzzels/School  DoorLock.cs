using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public bool doorIsOpen = false;
    public GameObject keyObject; // Assign the key object in the Inspector
    public Animator doorAnimator; // Assign the door's animator in the Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && keyObject != null)
        {
            keyObject.SetActive(false); // Hide the key
            doorIsOpen = true;
            doorAnimator.SetBool("IsOpen", true);
        }
    }
}
