using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogueScenario", menuName = "Dialogue/Scenario")]
public class DialogueScenario : ScriptableObject
{
    public CharacterProfile[] characterPositions = new CharacterProfile[4];
    public DialogueSequence dialogue;
}