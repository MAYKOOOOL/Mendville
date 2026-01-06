using TMPro;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    public string[] triviaText;
    public TextMeshProUGUI textBox;
    public int currentTriviaIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextTrivia()
    {
        textBox.text = triviaText[currentTriviaIndex];
    }


}
