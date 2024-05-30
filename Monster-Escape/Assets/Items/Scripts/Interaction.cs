using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Interaction : MonoBehaviour
{
    /*[SerializeField]
    private TextMeshProUGUI interactText;

    private bool interactAllowed;

    private void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (interactAllowed && Input.GetKeyDown(KeyCode.E))
            Interact();
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name.Equals("PlayerMovement"))
        {
            interactText.gameObject.SetActive(false);
            interactAllowed = false;
        }
    }

    private void Interact()
    {
        Destroy(gameObject);
    }*/

    public float interactDistance = 2f; // The maximum distance the player can be from the object to interact with it
    public KeyCode interactKey = KeyCode.E; // The key the player presses to interact

    private void Update()
    {
        // Check if the player is pressing the interact key and is within the interaction distance
        if (Input.GetKeyDown(interactKey) && IsPlayerNearby())
        {
            Interact();
        }
    }

    private bool IsPlayerNearby()
    {
        // Get the player's transform
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        // Check if the player is within the interaction distance
        return Vector3.Distance(transform.position, player.position) <= interactDistance;
    }

    private void Interact()
    {
        // Perform the interaction logic here
        Debug.Log("Interacting with the object!");
    }

}
