using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class checkerfoil : MonoBehaviour
{
    [Header("Gene Code Text (e.g., 'RrSs')")]
    public TextMeshProUGUI geneText; // Should be 4 characters long

    [Header("Player Input Fields")]
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    public TMP_InputField inputField4;

    [Header("Submit Button")]
    public bool Checked;

    private void Start()
    {
       

        // Add listeners so checking happens only when user types
        inputField1.onValueChanged.AddListener(delegate { CheckFOILAnswers(); });
        inputField2.onValueChanged.AddListener(delegate { CheckFOILAnswers(); });
        inputField3.onValueChanged.AddListener(delegate { CheckFOILAnswers(); });
        inputField4.onValueChanged.AddListener(delegate { CheckFOILAnswers(); });
    }

    // public void Update(){
    //     CheckFOILAnswers();
    // }

    public void CheckFOILAnswers()
    {
        string rawGenes = geneText.text.Trim();

        if (rawGenes.Length != 4)
        {
            Debug.LogError("Gene text must be exactly 4 characters long (e.g., 'RrSs').");
            return;
        }

        // Extract individual gene letters
        string gene1 = rawGenes[0].ToString();
        string gene2 = rawGenes[1].ToString();
        string gene3 = rawGenes[2].ToString();
        string gene4 = rawGenes[3].ToString();

        // FOIL combinations
        string foil1 = gene1 + gene3; // First
        string foil2 = gene1 + gene4; // Outer
        string foil3 = gene2 + gene3; // Inner
        string foil4 = gene2 + gene4; // Last

        // Player answers
        string ans1 = inputField1.text.Trim();
        string ans2 = inputField2.text.Trim();
        string ans3 = inputField3.text.Trim();
        string ans4 = inputField4.text.Trim();

        // Case-sensitive checks
        bool isCorrect1 = ans1 == foil1;
        bool isCorrect2 = ans2 == foil2;
        bool isCorrect3 = ans3 == foil3;
        bool isCorrect4 = ans4 == foil4;

        // Enable the button only if all are correct
        bool allCorrect = isCorrect1 && isCorrect2 && isCorrect3 && isCorrect4;
        Checked = allCorrect;

        // Debug info
        Debug.Log($"FOIL = {foil1}, {foil2}, {foil3}, {foil4}");
        

        // Optional: visual feedback
        SetInputFieldColor(inputField1, isCorrect1);
        SetInputFieldColor(inputField2, isCorrect2);
        SetInputFieldColor(inputField3, isCorrect3);
        SetInputFieldColor(inputField4, isCorrect4);
    }

    private void SetInputFieldColor(TMP_InputField inputField, bool isCorrect)
    {
        var colors = inputField.colors;
        colors.normalColor = isCorrect ? Color.green : Color.red;
        colors.selectedColor = isCorrect ? Color.green : Color.red;
        inputField.colors = colors;
    }
}
