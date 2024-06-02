using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeTransition : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(TransitionToHome());
    }

    private IEnumerator TransitionToHome()
    {
        Timer.SetLives(3);
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        SceneManager.LoadScene("Home"); // Load the "School" scene
    }
}
