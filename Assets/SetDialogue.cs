using UnityEngine;
using UnityEngine.UI;  

public class SetDialogue : MonoBehaviour
{
    public DialogueScenario dialogueScenario;
    public DialogueManager dialogueManager;
    public GameObject textObject;
    public Image background;
    public Sprite backgroundSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PassScenario()
    {
        if (backgroundSprite == null)
        {
            // Make background transparent
            Color transparent = background.color;
            transparent.a = 0f;
            background.color = transparent;
        }
        else
        {
            // Set sprite and make background fully visible
            background.sprite = backgroundSprite;

            Color opaque = background.color;
            opaque.a = 1f;
            background.color = opaque;
        }

        dialogueManager.SetScenario(dialogueScenario);
        textObject.SetActive(true);
    }

    
}
