using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CutScene: MonoBehaviour
{
    public TextMeshProUGUI khalidSubtitle;
    public TextMeshProUGUI uncleSubtitle;

    private void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    private IEnumerator PlayCutscene()
    {

        // Show first subtitle
        yield return StartCoroutine(ShowSubtitle(uncleSubtitle, "Khalid?!", 2f));

        yield return StartCoroutine(ShowSubtitle(khalidSubtitle, "Uncle! You're alive!", 5f));

        // Show second subtitle
        yield return StartCoroutine(ShowSubtitle(uncleSubtitle, "It is Miracle! I didn't expect to see my nephew here at all! How did you escape from all those monsters?", 8f));

        // Show third subtitle
        yield return StartCoroutine(ShowSubtitle(khalidSubtitle, "I don't know... I must've been lucky...", 5f));

        yield return StartCoroutine(ShowSubtitle(uncleSubtitle, "I see", 2f));

        yield return StartCoroutine(ShowSubtitle(khalidSubtitle, "Uncle... What is going on here? Where is Everyone?", 5f));
       

        // Show fourth subtitle
        yield return StartCoroutine(ShowSubtitle(uncleSubtitle, ".... I don't know.... I really don't know.", 5f));
        
        yield return StartCoroutine(ShowSubtitle(khalidSubtitle, "I guess... everyone... Died then...", 6f));

        yield return StartCoroutine(ShowSubtitle(uncleSubtitle, "I don't want to admit it.... but I am afraid so….. I searched for days but I couldn't find anyone", 6f));


        // Show fifth subtitle
        yield return StartCoroutine(ShowSubtitle(khalidSubtitle, ".... So that's it? Are we just going to... die?", 4f));

        // Show sixth subtitle
        yield return StartCoroutine(ShowSubtitle(uncleSubtitle, "No.... We can't let this happen. I almost lost all hope because everyone is gone.... But now.... You're here.... My Nephew. We can still survive this.", 9f));
        
        yield return StartCoroutine(ShowSubtitle(khalidSubtitle, "Uncle...", 2f));

        // Show seventh subtitle
        yield return StartCoroutine(ShowSubtitle(uncleSubtitle, "Come on, let's go to my shed. We could use things to save us from those monsters.", 4f));

        // Show eighth subtitle
        yield return StartCoroutine(ShowSubtitle(khalidSubtitle, "What?! You mean we have to run there?", 3f));

        // Show ninth subtitle
        yield return StartCoroutine(ShowSubtitle(uncleSubtitle, "It's our only chance. I tried to go but I couldn't because I was stuck here by the monsters surrounding my house. But now, since you came here, I'm positive our way to the shed will be safe.", 12f));
        yield return StartCoroutine(ShowSubtitle(uncleSubtitle, "So... will you come with me?", 6f));

        // Show tenth subtitle
        yield return StartCoroutine(ShowSubtitle(khalidSubtitle, ".... Yes. Let's go.", 5f));
    }

    private IEnumerator ShowSubtitle(TextMeshProUGUI subtitleText, string content, float duration)
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