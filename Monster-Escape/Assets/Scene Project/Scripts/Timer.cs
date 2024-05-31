using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text displayText; // Single text component for both time and lives
    private float minutes, seconds;
    private static int lives = 3; // Static variable for lives
    private float timerDuration = 120f; // Timer duration in seconds (2 minutes)
    private bool monsterTriggered = false; // Flag to ensure monster is only triggered once

    public GameObject enemy; // Reference to the enemy GameObject

    void Start()
    {
        // Initialize the timer
        UpdateDisplay(timerDuration);

        // Ensure the enemy is disabled at the start
        if (enemy != null)
        {
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease the timer
        timerDuration -= Time.deltaTime;

        // Check if time has run out
        if (timerDuration <= 0)
        {
            DecreaseLives();
        }

        // Trigger the monster if the remaining time is 20 seconds or less and the monster hasn't been triggered yet
        if (timerDuration <= 20f && !monsterTriggered)
        {
            TriggerMonster();
        }

        // Update UI texts
        UpdateDisplay(timerDuration);
    }

    void UpdateDisplay(float time)
    {
        minutes = (int)(time / 60f);
        seconds = (int)(time % 60f);
        displayText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00") + " | Lives: " + lives;
    }

    void ReloadScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GoToMainMenu()
    {
        Debug.Log("Going to Main Menu");
        SceneManager.LoadScene("Main Menu");  // Make sure the MainMenu scene is added in the build settings
    }

    void TriggerMonster()
    {
        monsterTriggered = true; // Set the flag to prevent triggering again
        if (enemy != null)
        {
            enemy.SetActive(true); // Activate the enemy GameObject
            Enemy_AI enemyAI = enemy.GetComponent<Enemy_AI>();
            if (enemyAI != null)
            {
                enemyAI.StartFollowing(); // Trigger the enemy's following behavior
            }
        }
    }

    public static void DecreaseLives()
    {
        lives -= 1;
        Debug.Log("Lives remaining: " + lives);
        if (lives > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (lives <= 0)
        {
            SceneManager.LoadScene("ScreenLose"); // Go to main menu if lives are 0 or less
        }
    }
}
