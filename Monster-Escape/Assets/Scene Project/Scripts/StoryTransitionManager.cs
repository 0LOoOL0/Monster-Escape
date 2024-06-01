
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryTransitionManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(TransitionToEnding());
    }

    private IEnumerator TransitionToEnding()
    {
        yield return new WaitForSeconds(88f); // Wait for seconds
        SceneManager.LoadScene("ScreenWin"); // Load the scene
    }
}
