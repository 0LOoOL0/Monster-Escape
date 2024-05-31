using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
    }

    public void StartFollowing()
    {
        StartCoroutine(StartFollowingAfterDelay(0f)); // Immediately start following
    }

    IEnumerator StartFollowingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        agent.destination = target.transform.position;
        PlayFollowSound();
    }

    void PlayFollowSound()
    {
        // Play the audio when the monster starts following the player
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy triggered with player");
            ReduceLife();
        }
    }

    public void ReduceLife()
    {
        Timer.DecreaseLives(); // Call a method on the Timer script to decrease lives
    }
}
