using UnityEngine;
using TMPro;

public class PutTrait : MonoBehaviour
{
    [SerializeField] private TMP_Text gene1; 
    [SerializeField] private TMP_Text gene2; 

    
    public void SetGene(string gene)
    {
        if (gene.Length == 2)
        {
            gene1.text = gene[0].ToString();
            gene2.text = gene[1].ToString();
        }
        else
        {
            gene1.text = "";
            gene2.text = "";
        }
    }

    // Clears the slot
    public void ClearGene()
    {
        gene1.text = "";
        gene2.text = "";
    }
}
