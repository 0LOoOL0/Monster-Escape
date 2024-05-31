
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverTransition : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(TransitionToMenu());
    }

    private IEnumerator TransitionToMenu()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        SceneManager.LoadScene("Main Menu"); // Load the "" scene
    }
}
