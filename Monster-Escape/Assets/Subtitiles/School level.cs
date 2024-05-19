using System.Collections;
using UnityEngine;
using UnityEngine.UI;
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
        StartCoroutine(ShowSubtitle(monsterApproachSubtitle, "The monster approaches...", 5f));
        StartCoroutine(ShowSubtitle(solvePuzzleSubtitle, "Can you solve the puzzle?", 7f));
        StartCoroutine(ShowSubtitle(escapeRoomSubtitle, "Find the exit from the escape room!", 9f));
        StartCoroutine(ShowSubtitle(ghostlyFootstepsSubtitle, "Did you hear those ghostly footsteps?", 11f));
        StartCoroutine(ShowSubtitle(lockedDoorSubtitle, "The door is locked... Can you unlock it?", 13f));

        // Starting delayed coroutines
        StartCoroutine(DelayedSubtitleCoroutine(monsterApproachSubtitle, "Run The monster is near!", 15f));
        StartCoroutine(DelayedSubtitleCoroutine(solvePuzzleSubtitle, "Time is running out Solve the puzzle quickly.", 17f));
        StartCoroutine(DelayedSubtitleCoroutine(escapeRoomSubtitle, "Escape the room before the monster finds you!", 19f));
        StartCoroutine(DelayedSubtitleCoroutine(ghostlyFootstepsSubtitle, "Who's there? The ghost is close!", 21f));
        StartCoroutine(DelayedSubtitleCoroutine(lockedDoorSubtitle, "Use the clues to unlock the door!", 23f));
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
