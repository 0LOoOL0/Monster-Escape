using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSchoolTransition : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(TransitionToSchool());
    }

    private IEnumerator TransitionToSchool()

    {
        Timer.SetLives(3); 
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        SceneManager.LoadScene("School"); // Load the "School" scene
    }
}
