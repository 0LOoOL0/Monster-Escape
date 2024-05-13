using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text counterText;
    private float minutes, seconds;

    // Update is called once per frame
    void Update()
    {
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}