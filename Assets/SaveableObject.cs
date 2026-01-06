using UnityEngine;

public class SaveableObject : MonoBehaviour
{
    public static SaveableObject Instance;

    public bool TutorialFinished;

    private void Awake()
    {
        // Singleton protection
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // -----------------------------
    // MARK TUTORIAL AS FINISHED
    // -----------------------------
    public void tapos()
    {
        TutorialFinished = true;
    }

    // -----------------------------
    // RESET SAVE (NEW GAME)
    // -----------------------------
    public void dae()
    {
        TutorialFinished = false;
    }
}
