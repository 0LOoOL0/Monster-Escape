using System.Collections;
using UnityEngine;

public class AudioListenerFinder : MonoBehaviour
{
    void Start()
    {
        Debug.Log("AudioListenerFinder script is running.");
        StartCoroutine(CheckAudioListeners());
    }

    IEnumerator CheckAudioListeners()
    {
        while (true)
        {
            AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();
            Debug.Log("Number of AudioListeners in the scene: " + audioListeners.Length);

            foreach (var listener in audioListeners)
            {
                Debug.Log("AudioListener found on GameObject: " + listener.gameObject.name);
            }

            yield return new WaitForSeconds(5f); // Check every 5 seconds
        }
    }
}
