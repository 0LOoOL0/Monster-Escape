using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HomeLevelSubtitleController : MonoBehaviour
{
    public TextMeshProUGUI findDadSubtitle;
    public TextMeshProUGUI hurrySubtitle;
    public TextMeshProUGUI findKeySubtitle;
    public TextMeshProUGUI puzzleSubtitle;
    public TextMeshProUGUI escapeMonsterSubtitle;
    public TextMeshProUGUI rescueDadSubtitle;
    public TextMeshProUGUI runFromCitySubtitle;
    public TextMeshProUGUI endSubtitle;

    private void Start()
    {
        // Starting coroutines immediately
        StartCoroutine(ShowSubtitle(findDadSubtitle, "I must find dad", 5f));
        StartCoroutine(ShowSubtitle(hurrySubtitle, "I must hurry before it's too late", 10f));
        StartCoroutine(ShowSubtitle(findKeySubtitle, "Find a key", 15f));
        StartCoroutine(ShowSubtitle(puzzleSubtitle, "Solve the first puzzle", 20f));
        StartCoroutine(ShowSubtitle(escapeMonsterSubtitle, "Escape from the monster", 25f));
        StartCoroutine(ShowSubtitle(rescueDadSubtitle, "Rescue dad from the home", 30f));
        StartCoroutine(ShowSubtitle(runFromCitySubtitle, "Run from the city before they catch us", 35f));

        // Starting delayed coroutines
        StartCoroutine(DelayedSubtitleCoroutine(findDadSubtitle, "Where is everybody?", 40f));
        StartCoroutine(DelayedSubtitleCoroutine(hurrySubtitle, "Why it's so quiet?", 45f));
        StartCoroutine(DelayedSubtitleCoroutine(findKeySubtitle, "It's a dream", 50f));
        StartCoroutine(DelayedSubtitleCoroutine(endSubtitle, "Hello, is anyone there?", 55f));
    }

    IEnumerator ShowSubtitle(TextMeshProUGUI subtitleText, string content, float duration)
    {
        if (subtitleText == null)
        {
            Debug.LogError("subtitleText is null. Please check your assignments in the Inspector.");
            yield break; // Exit the coroutine if subtitleText is null
        }

        subtitleText.gameObject.SetActive(true);
        subtitleText.text = content;

        yield return new WaitForSeconds(duration);

        subtitleText.gameObject.SetActive(false);
    }

    IEnumerator DelayedSubtitleCoroutine(TextMeshProUGUI subtitleText, string content, float duration)
    {
        yield return new WaitForSeconds(duration);
        StartCoroutine(ShowSubtitle(subtitleText, content, duration));
    }
}
