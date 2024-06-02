using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HospitalTransition : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(TransitionToHospital());
    }

    private IEnumerator TransitionToHospital()
    {
        Timer.SetLives(3);

        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        SceneManager.LoadScene("Hospital"); // Load the "Hospital" scene
    }
}
