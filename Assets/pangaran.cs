using UnityEngine;
using TMPro;

public class pangaran : MonoBehaviour
{
    public PlayerStats playerStats; // Reference to your PlayerStats script
    public TMP_Text nameDisplayText; // The UI text that will display the player's name

    void Start()
    {
        if (playerStats != null && nameDisplayText != null)
        {
            nameDisplayText.text = playerStats.playerName;
        }
        else
        {
            Debug.LogWarning("PlayerStats or NameDisplayText not assigned!");
        }
    }

    // Optional: If you want to update name dynamically later (e.g. after a delay)
    public void Update()
    {
        nameDisplayText.text = playerStats.playerName;
    }
}
