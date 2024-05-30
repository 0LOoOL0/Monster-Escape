using UnityEngine;

public class PickupKey : MonoBehaviour
{
    public GameObject keyObject; // Reference to the "Key" game object
    public GameObject keyPromptUI; // Reference to the "PickUpKeyGUI" UI element
    public float pickupRange = 2f; // The range within which the player can pick up the key

    private bool isKeyInRange;
    private Transform player; // Reference to the player's transform

    void Start()
    {
        // Find the player's transform by the name "teenageBoyFBK"
        player = GameObject.Find("teenageBoyFBK").transform;
    }

    void Update()
    {
        // Check if the player is in range of the key and the "E" key is pressed
        if (isKeyInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickupTheKey();
        }
    }

    void FixedUpdate()
    {
        // Check the distance between the player and the key
        float distance = Vector3.Distance(player.position, keyObject.transform.position);
        isKeyInRange = distance <= pickupRange;

        // Update the UI prompt based on the player's proximity to the key
        keyPromptUI.SetActive(isKeyInRange);
    }

    void PickupTheKey()
    {
        // Disable the key object and perform any other desired actions, such as adding the key to the player's inventory
        keyObject.SetActive(false);
        print("Key picked up!");
    }
}