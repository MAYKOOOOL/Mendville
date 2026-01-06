using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [SerializeField] private Image targetImage;                 // UI Image to display the character
    [SerializeField] private CharacterProfile characterProfile; // Reference to the ScriptableObject

    void Update()
    {
        if (characterProfile == null || targetImage == null)
        {
            Debug.LogWarning("CharacterProfile or TargetImage is not assigned.");
            return;
        }

        // Assign the first sprite from the array, if it exists
        if (characterProfile.characterSprites != null && characterProfile.characterSprites.Length > 0)
        {
            targetImage.sprite = characterProfile.characterSprites[0];
        }
        else
        {
            Debug.LogWarning("CharacterProfile has no sprites assigned.");
        }

        // Set the custom image size from the character profile
        RectTransform rectTransform = targetImage.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.sizeDelta = characterProfile.imageSize;
        }
    }
}
