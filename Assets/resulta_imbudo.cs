using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class resulta_imbudo : MonoBehaviour
{
    public TMP_Text Genes;
    public TMP_Text Color_Form;
    public Sprite itsura;
    public Embudo embudoScript;
    public Image spriteDisplay;

    private bool updated = false;

    void Update()
    {
        if (!updated && embudoScript != null && embudoScript.firstGeneCode != null)
        {
            updated = true;

            Genes.text = embudoScript.firstGeneCode;
            Color_Form.text = GetTraitTypeFromGene(embudoScript.firstGeneCode);
            itsura = embudoScript.firstSprite;

            if (spriteDisplay != null && itsura != null)
                spriteDisplay.sprite = itsura;
        }
    }

      private string GetTraitTypeFromGene(string gene)
    {
        if (string.IsNullOrEmpty(gene) || gene.Length != 2)
            return "Unknown";

        char[] alleles = gene.ToCharArray();
        System.Array.Sort(alleles);
        string normalized = new string(alleles);

        char allele1 = normalized[0];
        char allele2 = normalized[1];

        bool isAllele1Dominant = char.IsUpper(allele1);
        bool isAllele2Dominant = char.IsUpper(allele2);

        if (isAllele1Dominant && isAllele2Dominant)
            return "Homozygous Dominant";
        else if (!isAllele1Dominant && !isAllele2Dominant)
            return "Homozygous Recessive";
        else
            return "Heterozygous";
    }

   public void Reset()
{
 
    Genes.text = "";
    Color_Form.text = "";

 
    if (spriteDisplay != null)
        spriteDisplay.sprite = null;

    itsura = null;
    updated = false;


}

}
