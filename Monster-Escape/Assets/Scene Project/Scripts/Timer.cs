using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text displayText; // Single text component for both time and lives
    private float minutes, seconds;
    private static int lives = 3; // Static variable for lives
    private float timerDuration = 15f; // Timer duration in seconds (5 minutes)

    void Start()
    {
        // Initialize the timer
        UpdateDisplay(timerDuration);
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease the timer
        timerDuration -= Time.deltaTime;

        // Check if time has run out
        if (timerDuration <= 0)
        {
            lives -= 1;
            if (lives >= 0)
            {
                ReloadScene();
            }
            else
            {
                UpdateDisplay(0); // Update display to show 00:00 and lives as -1
                return;
            }
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
}
