using UnityEngine;
using UnityEngine.UI;

public class makuhaRes : MonoBehaviour
{
    public Embudo embudo;
    public Embudo embudo1;
    public string gene;

    private Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
        if (img == null)
            Debug.LogWarning("No Image component found on this GameObject.");
    }

    public void assign()
    {
        if (img == null)
            return;

        if (embudo != null && embudo.firstSprite != null)
        {
            img.sprite = embudo.firstSprite;
            gene = embudo.firstGeneCode;
        }
        else if (embudo1 != null && embudo1.firstSprite != null)
        {
            img.sprite = embudo1.firstSprite;
            gene = embudo1.firstGeneCode;
        }
        else
        {
            Debug.LogWarning("No valid Embudo found with a sprite.");
        }
    }

    public void remove()
    {
        if (img != null)
            img.sprite = null;

        gene = "";
    }
}
