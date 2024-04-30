using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    RaycastHit ray;
    bool hit;
    // Use this for initialization
    void Start()
    {
        hit = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 origin = transform.position + transform.up * 3;
        Vector3 destination = transform.forward;
        float distance = 5;
        //We cast a ray and output the result to the ray object.
        //Because this method returns a boolean, we assign it to the "hit" boolean
        //so that we check if our casted ray has hit anything.

        hit = Physics.Raycast(origin, destination, out ray, distance);
        //Optionally, we can draw the ray in the scene view (not in-game) to visualize it for testing
        Debug.DrawRay(origin, destination * distance, Color.red, 0.01f);
        //We only process the result of the casted ray IF it hits anything.
    if (hit)
            {
                if (ray.collider.gameObject.tag == "Player")
                {
                    print("GOTCHA!");
                }
            }
    }
}

