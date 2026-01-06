using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public string mission;

    public bool first;
    public bool second;
    public bool third;
    public bool fourth;
    public bool tapos = false;

    public GameObject manongben;
    public Button farm;
    public Button[] archive;
    public NPC npc;

    public GameObject dialog;
    public GameObject pop3;
    public GameObject pan;
    public GameObject[] kandado;
    public makuhaRes res;
    public Button[] but;

    public static Quest Instance;

    //private void Awake()
    //{
    //    if (Instance != null && Instance != this)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}


    void Start()
    {
        LoadQuest();
        UpdateQuestUI();
     
    }

    void Update()
    {
        UpdateQuestUI();
    }

   public void UpdateQuestUI()
    {
        var data = QuestManager.Instance.questData;

        if (tapos)
        {
            data.first = false;
            first = false;
            archive[0].interactable = true;
        }

        if (first && !tapos)
        {
            kandado[0].SetActive(false);
            mission = "dd";
            dialog.SetActive(false);
            archive[0].interactable = true;
        }
        else if (second)
        {
            kandado[0].SetActive(false);
            kandado[1].SetActive(false);
            mission = "Ss";
            
            archive[1].interactable = true;
        }
        else if (third)
        {
            
            mission = "ss";
           
        }
        else if (fourth)
        {
            kandado[0].SetActive(false);
            kandado[1].SetActive(false);
            kandado[2].SetActive(false);
            mission = "Gg";
            archive[2].interactable = true;
           
        }


        if (data.complete)
        {
            manongben.SetActive(true);
            farm.interactable = true;
        }
    }

    public void checker()
    {
        string playerAnswer = res.gene;
        var data = QuestManager.Instance.questData;

        if (first)
        {
            if (playerAnswer == mission)
            {
                Debug.Log("Tapos first mission");
                res.remove();

                first = false;
                second = true;
                tapos = true;
               data.first = false;
               data.second = true;
               data.tapos = true;
               
                npc.CompleteQuest();
                npc.PlayDialogue();
                SaveQuest();
            }
            else
            {
                tapos = false;
                Debug.Log("Sala");
            }
        }
        else if (second)
        {
            if (playerAnswer == mission)
            {
                Debug.Log("Tapos second mission");
                res.remove();

                second = false;
                third = true;
                data.second = false;
                data.third = true;
                
                npc.CompleteQuest();
                npc.PlayDialogue();
                SaveQuest();
            }
            else
            {
                Debug.Log("Sala");
            }
        }
        else if (third)
        {
            if (playerAnswer == mission)
            {
                Debug.Log("Tapos third mission");
                res.remove();

                third = false;
                fourth = true;
               data.third = false;
                data.fourth = true;
               
                npc.CompleteQuest();
                npc.PlayDialogue();
                pop3.SetActive(true);
                pan.SetActive(true);

                SaveQuest();
            }
            else
            {
                Debug.Log("Sala");
            }
        }
        else if (fourth)
        {
            if (playerAnswer == mission)
            {
                Debug.Log("Tapos fourth mission");
                res.remove();


                //npc.questIndex = 4;
                fourth = false;
                data.fourth = false;
                data.complete = true;
                npc.CompleteQuest();
                npc.PlayDialogue();
                SaveQuest();
            }
            else
            {
                Debug.Log("Sala");
            }
        }
    }

    public void ok()
    {
        first = true;
        SaveQuest();
    }

    // =========================
    // SAVE & LOAD
    // =========================

    public void SaveQuest()
    {
        var data = QuestManager.Instance.questData;
        data.first = first;
       data.second = second;
       data.third = third;
       data.fourth = fourth;
        data.tapos = tapos;
        //data.questind = npc.questIndex;
    }

    public void LoadQuest()
    {
        var data = QuestManager.Instance.questData;
        tapos = data.tapos;
        first = data.first;
        second = data.second;
        third = data.third;
        fourth = data.fourth;
    }

    // Optional: reset quest (for testing)
    public void ResetQuest()
    {
        PlayerPrefs.DeleteKey("Quest_first");
        PlayerPrefs.DeleteKey("Quest_second");
        PlayerPrefs.DeleteKey("Quest_third");
        PlayerPrefs.DeleteKey("Quest_fourth");
        PlayerPrefs.DeleteKey("Quest_tapos");

        first = false;
        second = false;
        third = false;
        fourth = false;
        tapos = false;
    }
    public void ContinueQuest()
    {
        LoadQuest();       // Load saved progress from PlayerPrefs
        UpdateQuestUI();   // Update UI/buttons based on the loaded state
        Debug.Log("Quest continued from saved state.");
    }
}
