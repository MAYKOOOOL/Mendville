using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public TMP_InputField playerInput;
    public CharacterProfile playerProfile;

    public Sprite[] maleSprites;
    public Sprite[] femaleSprites;

    public string playerName;
    public int gender = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetName()
    {
       playerName = playerInput.text;
        Debug.Log("Player Name: " + playerName);
        if (gender != 0)
        {
            for (int i = 0; i < femaleSprites.Length; i++)
            {
                playerProfile.characterSprites[i] = femaleSprites[i];
            }
        }
        else
        {
            for (int i = 0; i < maleSprites.Length; i++)
            {
                playerProfile.characterSprites[i] = maleSprites[i];
            }
        }
    }

    public void Gender(int num)
    {
        gender = num;
    }
}
