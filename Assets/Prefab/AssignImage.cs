using UnityEngine;
using UnityEngine.UI;
using TMPro; // Required for TextMeshPro

public class AssignImageAndTMPText : MonoBehaviour
{
    [Header("Image Change")]
    public Button targetButton;         // Button whose image will change
    public Sprite newSprite;            // New sprite to assign

    [Header("TMP Text Change")]
    public TextMeshProUGUI targetText;  // TextMeshProUGUI component
    public string newText;              // New text to display

    public void ChangeImageAndText()
    {
        // Change the image on the button
        if (targetButton != null && newSprite != null)
        {
            Image targetImage = targetButton.GetComponent<Image>();
            if (targetImage != null)
            {
                targetImage.sprite = newSprite;
                Debug.Log("Image changed on target button!");
            }
            else
            {
                Debug.LogWarning("Target Button has no Image component!");
            }
        }

        // Change the TMP UI text
        if (targetText != null)
        {
            targetText.text = newText;
            Debug.Log("TextMeshProUGUI text changed!");
        }
        else
        {
            Debug.LogWarning("No TMP Text assigned.");
        }
    }
}
