using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubtitleController : MonoBehaviour
{
    public TextMeshProUGUI findDadSubtitle;
    public TextMeshProUGUI hurrySubtitle;
    public TextMeshProUGUI findKeySubtitle;
    public TextMeshProUGUI endSubtitle;

    private void Start()
    {
        StartCoroutine(ShowSubtitle(findDadSubtitle, "I must find dad", 5f));
        StartCoroutine(ShowSubtitle(hurrySubtitle, "I must hurry before it's too late", 10f));
        StartCoroutine(ShowSubtitle(findKeySubtitle, "Find a key", 15f));
        StartCoroutine(ShowSubtitle(endSubtitle, "Let's end this once and for all", 20f));
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

}