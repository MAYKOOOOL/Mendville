using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public PlayerStats playerStats; // Reference to PlayerStats for player name
    public Animator dialogueAnimator;

    [Header("UI Elements")]
    public GameObject dialoguePanel;
    public GameObject textBoxObject;
    public TextMeshProUGUI dialogueTextBox;
    public float textSpeed = 0.05f;

    [Header("Character Images")]
    public Image[] characterImages = new Image[4]; // Positions 0 to 3

    [Header("Dialogue Data")]
    public DialogueScenario scenario;

    private CharacterProfile[] characters;  // Holds character data per position
    public DialogueLine[] lines;

    public int lineIndex = 0;

    private string fullText = "";
    private string displayedText = "";
    private float timer = 0f;
    private int charIndex = 0;
    public bool isTyping = false;

    void Start()
    {
        SetScenario(scenario);
    }

    void Update()
    {
        if (isTyping)
        {
            timer += Time.deltaTime;
            if (timer >= textSpeed && charIndex < fullText.Length)
            {
                displayedText += fullText[charIndex];
                dialogueTextBox.text = displayedText;
                charIndex++;
                timer = 0f;
            }

            if (charIndex >= fullText.Length)
            {
                isTyping = false;
            }
        }
    }

    public void SetScenario(DialogueScenario newScenario)
    {
        scenario = newScenario;
        Debug.Log("AAAAAAAAAAAAAAAA");
        characters = scenario.characterPositions;
        lines = scenario.dialogue.lines;

        lineIndex = 0;
        fullText = "";
        displayedText = "";
        charIndex = 0;
        timer = 0f;
        isTyping = false;

        SetupCharacterImages();
        StartTypingLine();
    }

    private void SetupCharacterImages()
    {
        for (int i = 0; i < characterImages.Length; i++)
        {
            if (characters.Length > i && characters[i] != null)
            {
                CharacterProfile profile = characters[i];

                // Check if the character has at least one valid sprite
                if (profile.characterSprites != null && profile.characterSprites.Length > 0 && profile.characterSprites[0] != null)
                {
                    characterImages[i].sprite = profile.characterSprites[0];
                    characterImages[i].gameObject.SetActive(true);

                    // Set custom width & height
                    RectTransform rect = characterImages[i].rectTransform;
                    rect.sizeDelta = profile.imageSize;

                    // Reset scale
                    rect.localScale = Vector3.one;
                }
                else
                {
                    // No sprite � disable image
                    characterImages[i].sprite = null;
                    characterImages[i].gameObject.SetActive(false);
                }
            }
            else
            {
                characterImages[i].sprite = null;
                characterImages[i].gameObject.SetActive(false);
            }
        }
    }


    private void StartTypingLine()
    {
        if (lineIndex >= lines.Length)
        {
            ClearDialogue();
            return;
        }

        DialogueLine currentLine = lines[lineIndex];
        int pos = currentLine.positionIndex;

        // Sprite setup (unchanged)
        if (pos >= 0 && pos < characters.Length && characters[pos] != null)
        {
            CharacterProfile profile = characters[pos];
            if (currentLine.spriteIndex >= 0 && currentLine.spriteIndex < profile.characterSprites.Length)
            {
                Sprite newSprite = profile.characterSprites[currentLine.spriteIndex];
                if (newSprite != null)
                {
                    characterImages[pos].sprite = newSprite;
                    characterImages[pos].rectTransform.sizeDelta = profile.imageSize;
                    characterImages[pos].gameObject.SetActive(true);
                }
                else
                {
                    characterImages[pos].sprite = null;
                    characterImages[pos].gameObject.SetActive(false);
                }
            }
        }

        // Highlight speaking character
        for (int i = 0; i < characterImages.Length; i++)
        {
            if (characterImages[i].gameObject.activeSelf)
            {
                Vector3 originalScale = characterImages[i].rectTransform.localScale;
                float xSign = Mathf.Sign(originalScale.x);
                float targetScale = (i == pos) ? 1.1f : 1f;
                characterImages[i].rectTransform.localScale = new Vector3(xSign * targetScale, targetScale, 1f);
            }
        }

        // Process text and check for [fadeOut]
        string processedText = ProcessDialogueText(currentLine.text);

        if (processedText.Contains("[fadeOut]"))
        {
            if (dialogueAnimator != null)
            {
                dialogueAnimator.SetTrigger("FadeOut");
            }

            // Remove the [fadeOut] tag from the displayed text
            processedText = processedText.Replace("[fadeOut]", "");
        }

        fullText = processedText;
        displayedText = "";
        charIndex = 0;
        timer = 0f;
        isTyping = true;

        textBoxObject.SetActive(true);
        dialoguePanel.SetActive(true);
    }


    public void NextText()
    {
        if (isTyping)
        {
            displayedText = fullText;
            dialogueTextBox.text = displayedText;
            charIndex = fullText.Length;
            isTyping = false;
        }
        else
        {
            lineIndex++;
            StartTypingLine();
        }
    }

    private string ProcessDialogueText(string input)
    {
        string playerName = playerStats != null && !string.IsNullOrEmpty(playerStats.playerName)
            ? playerStats.playerName
            : "Player";

        input = input.Replace("[playerName]", playerName);
        return input;
    }

    public void ClearDialogue()
    {
        fullText = "";
        displayedText = "";
        dialogueTextBox.text = "";
        charIndex = 0;
        isTyping = false;

        dialoguePanel.SetActive(false);
    }

    public bool IsDialogueFinished()
    {
        return lineIndex >= lines.Length && !isTyping;
    }
}
