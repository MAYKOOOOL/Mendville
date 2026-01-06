using UnityEngine;
using UnityEngine.UI;

public class Quest1 : MonoBehaviour
{
    public string mission;

    public GameObject flor;
    public Button flower;
    public Button[] archive;
    public GameObject machine;
    public NPC1 npc;
    public bool first;
    public bool second;
    public bool third;
    public bool fourth;
    public bool tapos = false;
    public GameObject[] kandado;
    public GameObject dialog;
    public GameObject pop3;
    public GameObject pan;

    public makuhaRes res;
    public Button[] but;

    public static Quest1 Instance;

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

    // =========================
    // QUEST UI / LOGIC
    // =========================
    public void UpdateQuestUI()
    {
        var data = QuestManager.Instance.quest2Data;

        if (tapos)
        {
            data.first = false;
            first = false;
        }

        if (first && !tapos)
        {
            kandado[0].SetActive(false);
            mission = "BB";
            archive[0].interactable = true;
            dialog.SetActive(false);
        }
        else if (second)
        {
            
            mission = "ss";
        }
        else if (third)
        {
            kandado[0].SetActive(false);
            kandado[1].SetActive(false);
            mission = "hh";
            archive[1].interactable = true;
        }
            else if (fourth)
        {
            kandado[0].SetActive(false);
            kandado[1].SetActive(false);
            kandado[2].SetActive(false);
            mission = "FF";
            archive[2].interactable = true;
        }
        if (data.complete)
        {
            machine.SetActive(true);
            flor.SetActive(true);
            flower.interactable = true;
        }
    }

    // =========================
    // CHECK ANSWER
    // =========================
    public void checker()
    {
       
        string playerAnswer = res.gene;
        var data = QuestManager.Instance.quest2Data;

        if (data.first)
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
                data.questind++;
                npc.CompleteQuest();
                npc.PlayDialogue();
 
            }
            else
            {
                data.tapos = false;
                Debug.Log("Sala");
            }
        }
        else if (data.second)
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

            }
            else
            {
                Debug.Log("Sala");
            }
        }
        else if (data.third)
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

            }
            else
            {
                Debug.Log("Sala");
            }
        }
        else if (data.fourth)
        {
            if (playerAnswer == mission)
            {
                Debug.Log("Tapos fourth mission");
                res.remove();


                fourth = false;
                data.fourth = false;
                data.complete = true;
                npc.CompleteQuest();
                npc.PlayDialogue();

            }
            else
            {
                Debug.Log("Sala");
            }
        }
    }

    // =========================
    // START QUEST
    // =========================
    public void ok()
    {
       
        first = true;
        SaveQuest();
    }
    public void SaveQuest()
    {
        var data = QuestManager.Instance.quest2Data;
        data.first = first;
        data.second = second;
        data.third = third;
        data.fourth = fourth;
        data.tapos = tapos;
        //data.questind = npc.questIndex;
    }

    public void LoadQuest()
    {
        var data = QuestManager.Instance.quest2Data;
        tapos = data.tapos;
        first = data.first;
        second = data.second;
        third = data.third;
        fourth = data.fourth;
    }


    // =========================
    // CONTINUE QUEST
    // =========================
    public void ContinueQuest()
    {
        QuestManager.Instance.LoadQuest();
        UpdateQuestUI();
        Debug.Log("Quest continued from saved state.");
    }
}
