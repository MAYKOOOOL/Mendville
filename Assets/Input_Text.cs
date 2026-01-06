using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Input_Text : MonoBehaviour
{
    [Header("Input Fields")]
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    public TMP_InputField inputField4;

    [Header("Target Text Fields")]
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;

    [Header("Button Image Transfer")]
    public Button sourceButton;     // Button with the image you want to copy
    public Button targetButton;     // Button where you want to assign the image

   
    public void AssignInputsToText()
    {
        text1.text = inputField1.text;
        text2.text = inputField2.text;
        text3.text = inputField3.text;
        text4.text = inputField4.text;
    }

   
    public void CopyButtonImage()
    {
        Image sourceImage = sourceButton.GetComponent<Image>();
        Image targetImage = targetButton.GetComponent<Image>();

        if (sourceImage != null && targetImage != null)
        {
            targetImage.sprite = sourceImage.sprite;
            targetImage.color = sourceImage.color; // Optional: copy color too
        }
        else
        {
            Debug.LogWarning("One of the buttons does not have an Image component.");
        }
    }

    
    public void AssignAll()
    {
        AssignInputsToText();
        CopyButtonImage();
    }
}
