using System.Collections;
using UnityEngine;
using TMPro;

public class HorrorSchoolSubtitleController : MonoBehaviour
{
    public TextMeshProUGUI monsterApproachSubtitle;
    public TextMeshProUGUI solvePuzzleSubtitle;
    public TextMeshProUGUI escapeRoomSubtitle;
    public TextMeshProUGUI ghostlyFootstepsSubtitle;
    public TextMeshProUGUI lockedDoorSubtitle;

    private void Start()
    {
        // Starting coroutines immediately
        StartCoroutine(ShowSubtitle(monsterApproachSubtitle, "I should find two puzzles...", 5f, 0f));
        StartCoroutine(ShowSubtitle(solvePuzzleSubtitle, "A telephone and a laptop!", 5f, 6f));
        StartCoroutine(ShowSubtitle(escapeRoomSubtitle, "Find the exit from the escape room!", 5f, 12f));
        StartCoroutine(ShowSubtitle(ghostlyFootstepsSubtitle, "Is this ghostly footsteps?", 5f, 18f));
        StartCoroutine(ShowSubtitle(lockedDoorSubtitle, "I should find the puzzles", 5f, 24f));

        // Starting delayed coroutines
        StartCoroutine(DelayedSubtitleCoroutine(monsterApproachSubtitle, "Hurry! The monster is near!", 5f, 30f));
        StartCoroutine(DelayedSubtitleCoroutine(solvePuzzleSubtitle, "Time is running out. Solve the puzzles quickly.", 5f, 36f));
        StartCoroutine(DelayedSubtitleCoroutine(escapeRoomSubtitle, "Escape the room before the monster finds you!", 5f, 42f));
        StartCoroutine(DelayedSubtitleCoroutine(ghostlyFootstepsSubtitle, "Who's there? The ghost is close!", 5f, 48f));
        StartCoroutine(DelayedSubtitleCoroutine(lockedDoorSubtitle, "Use the clues to escape!", 5f, 54f));
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
    }

    IEnumerator DelayedSubtitleCoroutine(TextMeshProUGUI subtitleText, string content, float duration, float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(ShowSubtitle(subtitleText, content, duration, 0f));
    }
}
