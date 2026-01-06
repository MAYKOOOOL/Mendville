using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class assign : MonoBehaviour
{
    public Trait traitScript;

    public TMP_Text child1;
    public TMP_Text child2;
    public TMP_Text child3;
    public TMP_Text child4;

    public Image form1;
    public Image form2;
    public Image form3;
    public Image form4;

    private bool assigned = false;

    void Update()
    {
        if (!assigned && traitScript != null && traitScript.allCorrect)
        {
            var children = traitScript.checker.GetPunnettSquare();

            if (children.Count < 4)
                return;

            Dictionary<string, int> geneCounts = new Dictionary<string, int>();
            foreach (var child in children)
            {
                string gene = child.geneCode.Trim();
                if (geneCounts.ContainsKey(gene))
                    geneCounts[gene]++;
                else
                    geneCounts[gene] = 1;
            }

            List<string> labels = new List<string>();
            List<Sprite> sprites = new List<Sprite>();
            HashSet<string> addedGenes = new HashSet<string>();

            foreach (var child in children)
            {
                string gene = child.geneCode.Trim();
                if (!addedGenes.Contains(gene))
                {
                    int count = geneCounts[gene];
                    string label = $"{gene} - {count}";
                    labels.Add(label);
                    addedGenes.Add(gene);
                }
            }

            // Assign labels safely (if less than 4, fill with empty string)
            child1.text = labels.Count > 0 ? labels[0] : "";
            child2.text = labels.Count > 1 ? labels[1] : "";
            child3.text = labels.Count > 2 ? labels[2] : "";
            child4.text = labels.Count > 3 ? labels[3] : "";

            // Now assign sprites using the original if/else but for unique genes only
            addedGenes.Clear();  // Reuse HashSet for sprites assignment
            int spriteIndex = 0;

            if (traitScript.checker.Is_Color)
            {
                // Iterate over children and assign unique sprites
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
                // Same for altSprite
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
    }

    public void utro()
    {
        // Reset assigned state
        assigned = false;

        // Clear text labels
        child1.text = "";
        child2.text = "";
        child3.text = "";
        child4.text = "";

        // Clear image sprites (you can also set a default sprite here if needed)
        form1.sprite = null;
        form2.sprite = null;
        form3.sprite = null;
        form4.sprite = null;
    }
}
