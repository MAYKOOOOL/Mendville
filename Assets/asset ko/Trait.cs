using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Trait : MonoBehaviour
{
    public Result checker;
    public TMP_InputField box1; 
    public TMP_InputField box2; 
    public TMP_InputField box3; 
    public TMP_InputField box4; 
    public bool allCorrect = false;
    public GameObject dial;
    public Button next;
    public Button next1;
    public Button next2;

    public void SubmitAnswers()
    {
        var correctChildren = checker.GetPunnettSquare();
        if (correctChildren.Count < 4)
        {

            return;
        }

        allCorrect = true;

        allCorrect &= checker.CheckSingleAnswer(box1.text, correctChildren[0].geneCode);
        allCorrect &= checker.CheckSingleAnswer(box2.text, correctChildren[1].geneCode);
        allCorrect &= checker.CheckSingleAnswer(box3.text, correctChildren[2].geneCode);
        allCorrect &= checker.CheckSingleAnswer(box4.text, correctChildren[3].geneCode);

    }

    private void Update()
    {
        SubmitAnswers();
        
        if (allCorrect)
        {
            next.interactable = true;
            next1.interactable = true;
            next2.interactable = true;
            dial.SetActive(true);
        }
        else
        {
            next.interactable = false;
            next1.interactable = false;
            next2.interactable = false;

        }


    }
}
