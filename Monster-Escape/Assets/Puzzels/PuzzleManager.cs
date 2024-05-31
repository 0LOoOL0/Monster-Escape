using UnityEngine;
using UnityEngine.SceneManagement;


public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }

    public bool isLaptopPuzzleSolved = false;
    public bool isTelephonePuzzleSolved = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckPuzzlesSolved()
    {
        if (isLaptopPuzzleSolved && isTelephonePuzzleSolved)
        {
            LoadHomeScene();
        }
    }

    private void LoadHomeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ScreenHome");
    }
}
