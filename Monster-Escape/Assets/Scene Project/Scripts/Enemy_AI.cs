using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject target;
    private AudioSource audioSource; // Private AudioSource

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartFollowingAfterDelay(10f));
    }

    IEnumerator StartFollowingAfterDelay(float delay)
    {
        Debug.LogError("Coroutine started");
        yield return new WaitForSeconds(delay);
        agent.destination = target.transform.position;
        Debug.LogError("Following started");
        PlayFollowSound();
    }

    void PlayFollowSound()
    {
        // Play the audio when the monster starts following the player
        if (audioSource != null)
        {
            audioSource.Play();
            Debug.LogError("Audio played");
        }
    }
}
