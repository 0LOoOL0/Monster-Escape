using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyGame_SubtitleController : MonoBehaviour
{
    public TextMeshProUGUI findDadSubtitle;
    public TextMeshProUGUI hurrySubtitle;
    public TextMeshProUGUI findKeySubtitle;
    public TextMeshProUGUI endSubtitle;

    private void Start()
    {
        // Starting coroutines immediately
        StartCoroutine(ShowSubtitle(findDadSubtitle, "Awakening from a deep sleep, you find yourself alone in a strange place.", 5f));
        StartCoroutine(ShowSubtitle(hurrySubtitle, "Where am I? Why does everything seem so unfamiliar?", 7f));
        StartCoroutine(ShowSubtitle(findKeySubtitle, "You must find help. You're not alone in this.", 9f));
        StartCoroutine(ShowSubtitle(endSubtitle, "Something's not right. There's a presence in the shadows. Stay calm, stay focused.", 11f));
        StartCoroutine(ShowSubtitle(findDadSubtitle, "To escape, you must solve the first puzzle. Look around for clues.", 13f));
        StartCoroutine(ShowSubtitle(findKeySubtitle, "Another piece of the puzzle. Keep moving, keep searching.", 15f));
        StartCoroutine(ShowSubtitle(endSubtitle, "The path to safety is clear. But the monster is getting closer. Hurry!", 17f));
        StartCoroutine(ShowSubtitle(hurrySubtitle, "With newfound courage, you start to escape. But the monster is relentless.", 19f));
        StartCoroutine(ShowSubtitle(findDadSubtitle, "One last puzzle stands between you and freedom. Can you solve it?", 21f));
        StartCoroutine(ShowSubtitle(endSubtitle, "You did it With courage and determination, you've escaped the hospital. Now, you must find a way home.", 23f));

        // Starting delayed coroutines
        StartCoroutine(DelayedSubtitleCoroutine(findDadSubtitle, "Why it's so quiet?", 25f));
        StartCoroutine(DelayedSubtitleCoroutine(hurrySubtitle, "Hello, is anyone there?", 27f));
        StartCoroutine(DelayedSubtitleCoroutine(findKeySubtitle, "Where is dad?", 29f));
        StartCoroutine(DelayedSubtitleCoroutine(endSubtitle, "I must find a way to get out from here", 31f));
        StartCoroutine(DelayedSubtitleCoroutine(hurrySubtitle, "What's that voice?", 33f));
        StartCoroutine(DelayedSubtitleCoroutine(endSubtitle, "Is someone here?", 35f));
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
