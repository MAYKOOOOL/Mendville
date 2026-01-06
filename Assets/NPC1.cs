using UnityEngine;
using UnityEngine.UI;

public class NPC1 : MonoBehaviour
{
    public DialogueScenario[] getQuest;
    public DialogueScenario duringQuest;
    public DialogueScenario afterQuest;

    public GameObject[] questPanel;
    public Quest1 quest;
    public bool hasQuest = false;
    //public int questIndex = 0;
    public DialogueManager dialogueManager;

    public Button questButton;
    void Start()
    {

    }

    public void PlayDialogue()
    {
        var data = QuestManager.Instance.quest2Data;

        // All quests (dialogues) completed
        if (data.questind >= getQuest.Length)
        {
            Debug.Log("pota");
            dialogueManager.SetScenario(afterQuest);
            questButton.gameObject.SetActive(false);
            return;
        }

        // Player has no active quest
        if (!hasQuest)
        {
            dialogueManager.SetScenario(getQuest[data.questind]);

            // Only give a quest if there's a panel available
            if (data.questind < questPanel.Length)
            {
                hasQuest = true;
                questButton.gameObject.SetActive(true);
            }
            else
            {
                // No panel left for quest, treat it as end of quests
                Debug.Log("No quest panel available for this dialogue. Ending quests.");
                hasQuest = false;
                questButton.gameObject.SetActive(false);
                data.questind++; // Advance index to stop repeating
            }
        }
        else
        {
            // Quest is currently active
            dialogueManager.SetScenario(duringQuest);
        }
    }
    public void questdial(int index)
    {
        dialogueManager.SetScenario(getQuest[index]);
    }
    public void CompleteQuest()
{
        var data = QuestManager.Instance.quest2Data;
        if (hasQuest)
    {
            data.questind++;
            hasQuest = false;
       
        questButton.gameObject.SetActive(false);
    }
    else
    {
        
    }
}



    public void OpenQuest()
    {
        var data = QuestManager.Instance.quest2Data;

        for (int i = 0; i < questPanel.Length; i++)
        {
            if (i == data.questind && hasQuest)
            {
                questPanel[i].SetActive(true);
                Debug.Log("tama");
            }
            else
            {
                questPanel[i].SetActive(false);
            } 
        }

        // if(questIndex == 0){
        //     quest.first = true;
        // }
    }
}
