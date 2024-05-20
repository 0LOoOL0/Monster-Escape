using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedRoom : MonoBehaviour
{
    public bool isKeyCollected = false;
    public GameObject door; // Assign this in the inspector

    void Update()
    {
        if (isKeyCollected && !door.activeInHierarchy)
        {
            door.SetActive(true);
            Debug.Log("Door Unlocked");
        }
    }

    public void CollectKey()
    {
        isKeyCollected = true;
    }
}
