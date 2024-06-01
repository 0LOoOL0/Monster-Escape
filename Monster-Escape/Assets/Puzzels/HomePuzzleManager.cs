using UnityEngine;

public class HomePuzzleManager : MonoBehaviour
{
    public static HomePuzzleManager Instance { get; private set; }

    public bool isCarPuzzleSolved = false;
    public bool isLampPuzzleSolved = false;

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
        if (isCarPuzzleSolved && isLampPuzzleSolved)
        {
            LoadCutScene();
        }
    }

    private void LoadCutScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CutScene");
    }
}
