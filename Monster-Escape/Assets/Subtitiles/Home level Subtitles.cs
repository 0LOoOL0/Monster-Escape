using System.Collections;
using UnityEngine;
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
        StartCoroutine(ShowSubtitle(findDadSubtitle, "I must find dad", 5f, 0f));
        StartCoroutine(ShowSubtitle(hurrySubtitle, "I must hurry before it's too late", 5f, 6f));
        StartCoroutine(ShowSubtitle(findKeySubtitle, "I should solve two puzzles", 5f, 12f));
        StartCoroutine(ShowSubtitle(puzzleSubtitle, "Solve the first puzzle", 5f, 18f));
        StartCoroutine(ShowSubtitle(escapeMonsterSubtitle, "Hurry, before the monster comes", 5f, 24f));
        StartCoroutine(ShowSubtitle(rescueDadSubtitle, "There are more houses I should check", 5f, 30f));
        StartCoroutine(ShowSubtitle(runFromCitySubtitle, "", 5f, 36f));

        // Starting delayed coroutines
        StartCoroutine(DelayedSubtitleCoroutine(findDadSubtitle, "Where is everybody?", 5f, 42f));
        StartCoroutine(DelayedSubtitleCoroutine(hurrySubtitle, "Why it's so quiet?", 5f, 48f));
        StartCoroutine(DelayedSubtitleCoroutine(findKeySubtitle, "It's a dream", 5f, 54f));
        StartCoroutine(DelayedSubtitleCoroutine(endSubtitle, "Hello, is anyone there?", 5f, 60f));
    }

    IEnumerator ShowSubtitle(TextMeshProUGUI subtitleText, string content, float duration, float delay)
    {
        if (subtitleText == null)
        {
            Debug.LogError("subtitleText is null. Please check your assignments in the Inspector.");
            yield break; // Exit the coroutine if subtitleText is null
        }

        yield return new WaitForSeconds(delay);

        Debug.Log("Showing subtitle: " + content);
        subtitleText.gameObject.SetActive(true);
        subtitleText.text = content;

        yield return new WaitForSeconds(duration);

        subtitleText.gameObject.SetActive(false);
        Debug.Log("Hiding subtitle: " + content);

        // Adding a short delay to ensure no overlap
        yield return new WaitForSeconds(1f);
    }

    IEnumerator DelayedSubtitleCoroutine(TextMeshProUGUI subtitleText, string content, float duration, float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(ShowSubtitle(subtitleText, content, duration, 0f));
    }
}
