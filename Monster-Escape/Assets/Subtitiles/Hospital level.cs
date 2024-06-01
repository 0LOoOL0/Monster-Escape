using System.Collections;
using UnityEngine;
using TMPro;

public class MyGame_SubtitleController : MonoBehaviour
{
    public TextMeshProUGUI findDadSubtitle;
    public TextMeshProUGUI hurrySubtitle;
    public TextMeshProUGUI findKeySubtitle;
    public TextMeshProUGUI endSubtitle;

    private void Start()
    {
        // Sequentially show subtitles with adjusted timings
        StartCoroutine(ShowAllSubtitles());
    }

    IEnumerator ShowAllSubtitles()
    {
        yield return ShowSubtitle(findDadSubtitle, "Awakening from a deep sleep, you find yourself alone in a strange place.", 5f);
        yield return ShowSubtitle(hurrySubtitle, "Where am I? Why does everything seem so unfamiliar?", 5f);
        yield return ShowSubtitle(findKeySubtitle, "You must find help. You're not alone in this.", 5f);
        yield return ShowSubtitle(endSubtitle, "Something's not right. There's a presence in the shadows. Stay calm, stay focused.", 5f);
        yield return ShowSubtitle(findDadSubtitle, "To escape, I must solve the puzzle. Look around for clues.", 5f);
        yield return ShowSubtitle(findKeySubtitle, "Keep moving, keep searching.", 5f);
        yield return ShowSubtitle(endSubtitle, "The path to safety is clear. But the monster can appear soon. Hurry!", 5f);
        yield return ShowSubtitle(hurrySubtitle, "With newfound courage, you start to escape. But the monster is relentless.", 5f);
        yield return ShowSubtitle(findDadSubtitle, "A puzzle stands between me and freedom. Can I solve it?", 5f);
        yield return ShowSubtitle(endSubtitle, "I will do it with courage and determination, I have to escape the hospital. Now, I must find a way out.", 5f);

        // Delayed subtitles
        yield return new WaitForSeconds(5f);
        yield return ShowSubtitle(findDadSubtitle, "Why it's so quiet?", 5f);
        yield return new WaitForSeconds(5f);
        yield return ShowSubtitle(hurrySubtitle, "Hello, is anyone there?", 5f);
        yield return new WaitForSeconds(5f);
        yield return ShowSubtitle(findKeySubtitle, "Where is dad?", 5f);
        yield return new WaitForSeconds(5f);
        yield return ShowSubtitle(endSubtitle, "I must find a way to get out from here", 5f);
        yield return new WaitForSeconds(5f);
        yield return ShowSubtitle(hurrySubtitle, "What's that voice?", 5f);
        yield return new WaitForSeconds(5f);
        yield return ShowSubtitle(endSubtitle, "Is someone here?", 5f);
    }

    IEnumerator ShowSubtitle(TextMeshProUGUI subtitleText, string content, float duration)
    {
        if (subtitleText == null)
        {
            Debug.LogError("subtitleText is null. Please check your assignments in the Inspector.");
            yield break;
        }

        Debug.Log("Showing subtitle: " + content);
        subtitleText.gameObject.SetActive(true);
        subtitleText.text = content;

        yield return new WaitForSeconds(duration);

        subtitleText.gameObject.SetActive(false);
        Debug.Log("Hiding subtitle: " + content);

        // Adding a short delay to ensure no overlap
        yield return new WaitForSeconds(1f);
    }
}
