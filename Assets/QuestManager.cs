using UnityEngine;

public class QuestManager: MonoBehaviour
{
    public static QuestManager Instance;

    public Quest1Data questData = new Quest1Data();
    public Quest2Data quest2Data = new Quest2Data();
    public bool inot;
    public bool duwa;
    public bool tulo;
    public bool apat;
    public bool finish;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Save quest data to PlayerPrefs
    public void SaveQuest()
    {
        inot = questData.first;
        duwa = questData.second;
        tulo = questData.third;
        apat = questData.fourth;
        finish = questData.tapos;
        //PlayerPrefs.SetInt("Quest_first", questData.first ? 1 : 0);
        //PlayerPrefs.SetInt("Quest_second", questData.second ? 1 : 0);
        //PlayerPrefs.SetInt("Quest_third", questData.third ? 1 : 0);
        //PlayerPrefs.SetInt("Quest_fourth", questData.fourth ? 1 : 0);
        //PlayerPrefs.SetInt("Quest_tapos", questData.tapos ? 1 : 0);
        //PlayerPrefs.Save();
    }

    // Load quest data from PlayerPrefs
    public void LoadQuest()
    {
       
    }

    // Optional: reset quest
    public void ResetQuest()
    {
        PlayerPrefs.DeleteKey("Quest_first");
        PlayerPrefs.DeleteKey("Quest_second");
        PlayerPrefs.DeleteKey("Quest_third");
        PlayerPrefs.DeleteKey("Quest_fourth");
        PlayerPrefs.DeleteKey("Quest_tapos");

        questData.first = false;
        questData.second = false;
        questData.third = false;
        questData.fourth = false;
        questData.tapos = false;
    }
}
