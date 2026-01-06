using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MendVille : MonoBehaviour
{
    public static MendVille Instance;

    public SaveableObject saved;

    public GameObject[] tutorial;
    public GameObject[] main;
    public bool nagsave;
    public bool cont;

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

    private void Start()
    {
        FindSave();
        DetectTutorialAndMainObjects();
        UpdateTutorialObjects();
    }

    public void Update()
    {
        DetectTutorialAndMainObjects();
        if (saveass.Instance.padagos)
        {
            UpdateTutorialObjects();
            
        }
    }
    // -----------------------------
    // FIND SAVE OBJECT
    // -----------------------------
    private void FindSave()
    {
        saved = FindAnyObjectByType<SaveableObject>();
    }

    // -----------------------------
    // DETECT TUTORIAL / MAIN OBJECTS
    // -----------------------------
    private void DetectTutorialAndMainObjects()
    {
        TutorialTag[] allTaggedObjects = FindObjectsOfType<TutorialTag>(true);

        List<GameObject> tutorialList = new List<GameObject>();
        List<GameObject> mainList = new List<GameObject>();

        foreach (TutorialTag obj in allTaggedObjects)
        {
            if (obj.type == TutorialTag.Type.Tutorial)
                tutorialList.Add(obj.gameObject);
            else if (obj.type == TutorialTag.Type.Main)
                mainList.Add(obj.gameObject);
        }

        tutorial = tutorialList.ToArray();
        main = mainList.ToArray();
    }

    // -----------------------------
    // UPDATE OBJECT STATES
    // -----------------------------
    public void UpdateTutorialObjects()
    {
        if (saved == null) return;

        bool finished = saved.TutorialFinished;

        if (cont)
        {
            // Normal tutorial logic
            foreach (GameObject obj in tutorial)
                if (obj != null)
                    obj.SetActive(!finished);

            foreach (GameObject obj in main)
                if (obj != null)
                    obj.SetActive(finished);
        }
        else
        {
            // Continue mode (skip tutorial)
            foreach (GameObject obj in tutorial)
                if (obj != null)
                    obj.SetActive(true);

            foreach (GameObject obj in main)
                if (obj != null)
                    obj.SetActive(false);
        }
    }

    // -----------------------------
    // FINISH TUTORIAL
    // -----------------------------
    public void FinishTutorial()
    {
        if (saved == null) return;

        saved.TutorialFinished = true;
        UpdateTutorialObjects();
    }

    // -----------------------------
    // CONTINUE GAME
    // -----------------------------
    public void AllowContinue()
    {
        cont = true;
        UpdateTutorialObjects();
    }

    public void pad()
    {
        saveass.Instance.padagos = false;
    }
    public void pad1()
    {
        if (saveass.Instance != null)
            Destroy(saveass.Instance.gameObject);
        nagsave = true;
    }
    // -----------------------------
    // NEW GAME (IMPORTANT)
    // -----------------------------
    public void NewGame(string sceneName)
    {
        cont = false;

        if (saved != null)
        {
            saved.TutorialFinished = false;
        }

        SceneManager.LoadScene(sceneName);
    }
}
