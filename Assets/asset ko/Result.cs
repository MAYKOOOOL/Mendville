using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ChildResult
{
    public string geneCode;
    public Sprite colorSprite;  
    public Sprite altSprite;    

    public ChildResult(string code, Sprite color, Sprite alt)
    {
        geneCode = code;
        colorSprite = color;
        altSprite = alt;
    }
}

public class Result : MonoBehaviour
{
    public slot3 parent1Slot;
    public slot2 parent2Slot;
    public bool Is_Color;
    public GameObject note;
    public GameObject note1;
    public GameObject dial;
    public bool IsBarn;
    public GameObject tutor;
    public bool allAnswersCorrect = false;
    public List<ChildResult> childForms = new List<ChildResult>();
    public List<ChildResult> barnChildForms = new List<ChildResult>(); // <-- Alternative list

    private Trait trait;

    public List<ChildResult> GetPunnettSquare()
    {
        List<ChildResult> children = new List<ChildResult>();

        if (parent1Slot.assignedScriptable == null || parent2Slot.assignedScriptable == null)
            return children;

        var p1 = parent1Slot.assignedScriptable;
        var p2 = parent2Slot.assignedScriptable;

        string[] codes =
        {
            p1.gene1 + p2.gene1,
            p1.gene1 + p2.gene2,
            p1.gene2 + p2.gene1,
            p1.gene2 + p2.gene2
        };

        foreach (string code in codes)
        {
            string normalized = Normalize(code);
            Sprite sprite = GetSpriteForGene(normalized);
            children.Add(new ChildResult(normalized, Is_Color ? sprite : null, !Is_Color ? sprite : null));
        }

        return children;
    }

    public void Update () {
        if(IsBarn){
            note1.SetActive(true);
            note.SetActive(false);
            dial.SetActive(true);
        }else{
            note1.SetActive(false);
            note.SetActive(true);
            dial.SetActive(false);
        }



        if (allAnswersCorrect)
        {
            tutor.SetActive(true);
        }
    }

    public void barns(){
        IsBarn = true;
    }
    public void barn(){
        IsBarn = false;
    }


    private List<ChildResult> CurrentChildForms()
    {
        return IsBarn ? barnChildForms : childForms;
    }

    private string Normalize(string gene)
    {
        char[] chars = gene.ToCharArray();
        System.Array.Sort(chars);
        return new string(chars);
    }

    private Sprite GetSpriteForGene(string geneCode)
    {
        string normalizedCode = Normalize(geneCode);

        foreach (var child in CurrentChildForms())
        {
            if (Normalize(child.geneCode) == normalizedCode)
            {
                return Is_Color ? child.colorSprite : child.altSprite;
            }
        }

        return null;
    }

    public bool CheckSingleAnswer(string playerInput, string correctAnswer)
    {
        return Normalize(playerInput) == Normalize(correctAnswer);
    }

    public Sprite AssignFormBasedOnPlayerInput(string playerInput)
    {
        string normalizedInput = Normalize(playerInput);
        return GetSpriteForGene(normalizedInput);
    }

    public bool AreAllAnswersCorrect(List<string> playerInputs)
    {
        var correctChildren = GetPunnettSquare();

        if (playerInputs == null || playerInputs.Count != 4 || correctChildren.Count != 4)
        {
            allAnswersCorrect = false; 
            return false;
        }

        for (int i = 0; i < 4; i++)
        {
            string normalizedPlayerInput = Normalize(playerInputs[i]);
            string normalizedCorrectAnswer = Normalize(correctChildren[i].geneCode);

            if (normalizedPlayerInput != normalizedCorrectAnswer)
            {
                allAnswersCorrect = false;
                return false;
            }

            Debug.Log("Tama");
        }

        allAnswersCorrect = true; 
        return true;
    }


    public void palit() { Is_Color = true; }
    public void palit1() { Is_Color = false; }
}
