using UnityEngine;


[CreateAssetMenu(fileName = "NewCharacterProfile", menuName = "Dialogue/Character Profile")]
public class CharacterProfile : ScriptableObject
{
    public string characterName;
    public Sprite[] characterSprites;

    [Header("Custom Size")]
    public Vector2 imageSize = new Vector2(300, 500); // Default size, customize per character
}
