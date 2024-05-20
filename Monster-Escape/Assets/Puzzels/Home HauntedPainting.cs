using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntedPainting : MonoBehaviour
{
    public GameObject exitObject; // Assign the exit object in the Inspector
    public GameObject[] peacefulItems; // Assign peaceful items in the Inspector

    void Update()
    {
        foreach (GameObject item in peacefulItems)
        {
            if (item.activeInHierarchy)
            {
                exitObject.SetActive(true); // Reveal the exit
                Debug.Log("Exit Revealed!");
                // Proceed to the next level or scene
            }
        }
    }
}