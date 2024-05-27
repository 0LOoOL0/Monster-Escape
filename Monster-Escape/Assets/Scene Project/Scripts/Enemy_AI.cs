using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;  // Add this for scene management

public class Enemy_AI : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject target;
    private AudioSource audioSource; // Private AudioSource
    public int playerLives = 3;      // Add this to track player lives

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

    public void ReduceLife()
    {
        playerLives--;
        Debug.Log("Player lives reduced: " + playerLives); // Add this debug statement
        //if (playerLives <= 0)
        //{
        //    GoToMainMenu();
        //}
    }

    //void GoToMainMenu()
    //{
    //    Debug.Log("Going to Main Menu"); // Add this debug statement
    //    SceneManager.LoadScene("Main Menu");  // Make sure the MainMenu scene is added in the build settings
    //}
}