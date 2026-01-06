using UnityEngine;

[CreateAssetMenu(fileName = "fourbaifour", menuName = "obs/4bai4")]
public class fourbaifour : ScriptableObject
{
    [Header("Gene Information")]
    public string gene1;
    public string gene2;
    public string gene4;
    public string gene3;
    public string geneType;

    [Header("Color")]
    public string colorCode = "#FFFFFF";
}
