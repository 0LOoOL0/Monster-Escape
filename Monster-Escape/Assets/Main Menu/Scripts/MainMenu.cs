using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void Play() {
        ScenceManager.LoadScene(SceneManager.GetActionScene().buildIndex + 1);
    }


    public void Quit() {
        Application.Quit();

    }

}
