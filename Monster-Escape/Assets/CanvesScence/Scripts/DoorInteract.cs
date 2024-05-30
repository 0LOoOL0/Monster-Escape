using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoorInteractScript
{
    public class DoorInteract : MonoBehaviour
    {
        public float DistanceOpen = 5f; // Increase the distance to open the door
        public float raycastWidth = 1f; // Width of the ray casting area
        public GameObject text;
        public Transform player; // Reference to the player's transform

        void Start()
        {
            // Find the player's transform by the name "TeenageBoyFBX"
            player = GameObject.Find("teenageBoyFBX").transform;
        }

        void Update()
        {
            RaycastHit[] hits;
            Vector3 raycastOrigin = player.position + (player.forward * 1.5f); // Offset the ray origin slightly forward
            Vector3 raycastDirection = player.forward;

            // Cast a ray with a width to cover a wider area around the player
            hits = Physics.RaycastAll(raycastOrigin, raycastDirection, DistanceOpen, ~(1 << LayerMask.NameToLayer("Player")));

            bool foundDoor = false;
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.GetComponent<DoorScript.Door>())
                {
                    foundDoor = true;
                    text.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                        hit.transform.GetComponent<DoorScript.Door>().OpenDoor();
                    break;
                }
            }

            if (!foundDoor)
            {
                text.SetActive(false);
            }
        }
    }
}
