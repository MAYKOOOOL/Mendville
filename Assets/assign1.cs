using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class assign1 : MonoBehaviour
{
    public Trait traitScript;
    public Result res;
    public TMP_Text child1Label;
    public TMP_Text child2Label;
    public TMP_Text child3Label;
    public TMP_Text child4Label;

    public TMP_InputField child1Input;
    public TMP_InputField child2Input;
    public TMP_InputField child3Input;
    public TMP_InputField child4Input;

    public Image form1;
    public Image form2;
    public Image form3;
    public Image form4;

    public Button button1;
    public Button button2;
    public bool puon;

    private bool assigned = false;

    private Dictionary<string, int> correctGeneCounts = new Dictionary<string, int>();

    void Update()
{
    if (res != null && res.IsBarn)
    {
        if (!assigned && traitScript != null && traitScript.allCorrect)
        {
            var children = traitScript.checker.GetPunnettSquare();

            if (children.Count < 4)
                return;

            // Count gene occurrences
            Dictionary<string, int> geneCounts = new Dictionary<string, int>();
            foreach (var child in children)
            {
                string gene = child.geneCode.Trim();
                if (geneCounts.ContainsKey(gene))
                    geneCounts[gene]++;
                else
                    geneCounts[gene] = 1;
            }

            List<string> geneLabels = new List<string>();
            HashSet<string> addedGenes = new HashSet<string>();

            foreach (var child in children)
            {
                string gene = child.geneCode.Trim();
                if (!addedGenes.Contains(gene))
                {
                    geneLabels.Add(gene);
                    addedGenes.Add(gene);
                }
            }

            // Assign gene labels (not counts)
            child1Label.text = geneLabels.Count > 0 ? geneLabels[0] : "";
            child2Label.text = geneLabels.Count > 1 ? geneLabels[1] : "";
            child3Label.text = geneLabels.Count > 2 ? geneLabels[2] : "";
            child4Label.text = geneLabels.Count > 3 ? geneLabels[3] : "";

            // Save correct counts
            correctGeneCounts = geneCounts;

            // Assign sprites
            addedGenes.Clear();
            int spriteIndex = 0;

            if (traitScript.checker.Is_Color)
            {
                foreach (var child in children)
                {
                    string gene = child.geneCode.Trim();
                    if (!addedGenes.Contains(gene))
                    {
                        if (spriteIndex == 0) form1.sprite = child.colorSprite;
                        else if (spriteIndex == 1) form2.sprite = child.colorSprite;
                        else if (spriteIndex == 2) form3.sprite = child.colorSprite;
                        else if (spriteIndex == 3) form4.sprite = child.colorSprite;

                        addedGenes.Add(gene);
                        spriteIndex++;
                        if (spriteIndex >= 4) break;
                    }
                }
            }
            else
            {
                foreach (var child in children)
                {
                    string gene = child.geneCode.Trim();
                    if (!addedGenes.Contains(gene))
                    {
                        if (spriteIndex == 0) form1.sprite = child.altSprite;
                        else if (spriteIndex == 1) form2.sprite = child.altSprite;
                        else if (spriteIndex == 2) form3.sprite = child.altSprite;
                        else if (spriteIndex == 3) form4.sprite = child.altSprite;

                        addedGenes.Add(gene);
                        spriteIndex++;
                        if (spriteIndex >= 4) break;
                    }
                }
            }

            assigned = true;
        }

        // Continuously check if all inputs are correct
        if (assigned && res.IsBarn)
        {
            CheckAllAnswers();
        }
    }
}


    void CheckAllAnswers()
    {
        bool allCorrect = true;

        allCorrect &= CheckAndColor(child1Label.text, child1Input);
        allCorrect &= CheckAndColor(child2Label.text, child2Input);
        allCorrect &= CheckAndColor(child3Label.text, child3Input);
        allCorrect &= CheckAndColor(child4Label.text, child4Input);

        button1.interactable = allCorrect;
        button2.interactable = allCorrect;


    }

    bool CheckAndColor(string geneLabel, TMP_InputField inputField)
    {
        if (string.IsNullOrWhiteSpace(geneLabel)) return true;

        int expectedCount;
        if (!correctGeneCounts.TryGetValue(geneLabel.Trim(), out expectedCount))
            return true;

        if (int.TryParse(inputField.text.Trim(), out int playerInput))
        {
            if (playerInput == expectedCount)
            {
                inputField.textComponent.color = Color.green;
                return true;
            }
            else
            {
                inputField.textComponent.color = Color.red;
                return false;
            }
        }
        else
        {
            inputField.textComponent.color = Color.red;
            return false;
        }
    }

    public void utro()
    {
       

        
        button1.interactable = false;
        button2.interactable = false;
       
    }

    public void panduwa()
    {
        assigned = false;

        // Clear gene labels
        child1Label.text = "";
        child2Label.text = "";
        child3Label.text = "";
        child4Label.text = "";

        // Clear image sprites
        form1.sprite = null;
        form2.sprite = null;
        form3.sprite = null;
        form4.sprite = null;

       
    }
}
