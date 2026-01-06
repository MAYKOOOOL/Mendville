using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class PunnettBreederChecker : MonoBehaviour
{
    [Header("Parent 1 Gene Boxes (Each 2 alleles like 'RS')")]
    public TextMeshProUGUI[] parent1Genes = new TextMeshProUGUI[4];

    [Header("Parent 2 Gene Boxes (Each 2 alleles like 'Rs')")]
    public TextMeshProUGUI[] parent2Genes = new TextMeshProUGUI[4];

    [Header("Player Input Fields (16 Offspring)")]
    public TMP_InputField[] inputFields = new TMP_InputField[16];

    [Header("Submit Button")]
    public Button submitButton;

    [Header("Offspring Images (Optional)")]
    public Image[] offspringImages = new Image[16];

    [System.Serializable]
    public class GenotypeImage
    {
        public string genotype;     // e.g., "RrSs"
        public Sprite sprite;       // Corresponding image
    }

    [Header("Genotype to Sprite Map")]
    public GenotypeImage[] genotypeSpriteMap;

    private Dictionary<string, Sprite> spriteLookup = new Dictionary<string, Sprite>();
    private string[] correctOffspring = new string[16];

    private void Start()
    {
        // Build dictionary for genotype to sprite mapping
        foreach (var entry in genotypeSpriteMap)
        {
            if (!spriteLookup.ContainsKey(entry.genotype))
            {
                spriteLookup.Add(entry.genotype, entry.sprite);
            }
        }

        GenerateCorrectOffspring();
        submitButton.interactable = false;
    }

    private void Update()
    {
        GenerateCorrectOffspring();
        CheckPlayerAnswers();
    }

    void GenerateCorrectOffspring()
    {
        int index = 0;

        for (int i = 0; i < 4; i++) // Parent 1 gene boxes
        {
            string p1 = parent1Genes[i].text.Trim();
            if (p1.Length != 2)
            {
                Debug.LogError($"Parent 1 gene box {i + 1} must have 2 letters.");
                return;
            }

            for (int j = 0; j < 4; j++) // Parent 2 gene boxes
            {
                string p2 = parent2Genes[j].text.Trim();
                if (p2.Length != 2)
                {
                    Debug.LogError($"Parent 2 gene box {j + 1} must have 2 letters.");
                    return;
                }

                // Combine: P1[0] + P2[0] + P1[1] + P2[1]
                string child = $"{p1[0]}{p2[0]}{p1[1]}{p2[1]}";
                correctOffspring[index] = child;
                index++;
            }
        }
    }

    void CheckPlayerAnswers()
    {
        bool allCorrect = true;

        for (int i = 0; i < 16; i++)
        {
            string playerInput = inputFields[i].text.Trim();
            string expected = correctOffspring[i];

            bool isCorrect = playerInput == expected; // case-sensitive
            SetInputColor(inputFields[i], isCorrect);
            UpdateImageFromInput(i, playerInput);

            if (!isCorrect)
                allCorrect = false;
        }

        submitButton.interactable = allCorrect;
    }

    void SetInputColor(TMP_InputField field, bool isCorrect)
    {
        var colors = field.colors;
        colors.normalColor = isCorrect ? Color.green : Color.red;
        colors.selectedColor = isCorrect ? Color.green : Color.red;
        field.colors = colors;
    }

    void UpdateImageFromInput(int index, string playerInput)
    {
        if (index >= offspringImages.Length) return;

        if (spriteLookup.TryGetValue(playerInput, out Sprite foundSprite))
        {
            offspringImages[index].sprite = foundSprite;
        }
        else
        {
            offspringImages[index].sprite = null; // Or set to a default/placeholder sprite
        }
    }
}
