using UnityEngine;

[CreateAssetMenu(fileName = "scriptabe", menuName = "obs/script")]
public class Scriptable : ScriptableObject
{
    [Header("Gene Information")]
    public string gene1;
    public string gene2;
    public string geneType;

    [Header("Color")]
    public string colorCode = "#FFFFFF";

    public Sprite geneSprite;
    public Color GetColor()
    {
        if (ColorUtility.TryParseHtmlString(colorCode, out Color parsedColor))
        {
            return parsedColor;
        }
        return Color.white;
    }
}
