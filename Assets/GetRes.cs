using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetRes : MonoBehaviour
{
    [Header("Gene Result System")]
    [SerializeField] private Result resultSystem;

    [Header("Input Fields")]
    [SerializeField] private TMP_InputField[] inputFields;

    [Header("Output Images")]
    [SerializeField] private Image[] outputImages;

    public void display()
    {
        for (int i = 0; i < inputFields.Length; i++)
        {
            string input = inputFields[i].text;
            Sprite resultSprite = resultSystem.AssignFormBasedOnPlayerInput(input);

            if (resultSprite != null)
                outputImages[i].sprite = resultSprite;
        }
    }
}
