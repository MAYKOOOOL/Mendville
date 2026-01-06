using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Notebook2 : MonoBehaviour
{
    //public TextMeshProUGUI textBox;
    public Sprite[] image;
    public Image displayImage;
    public GameObject textDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayText(int index)
    {
        if(index != 0)
        {
            textDisplay.SetActive(false);
            displayImage.sprite = image[index];
            displayImage.SetNativeSize();
        }
        else
        {
            textDisplay.SetActive(true);
            displayImage.gameObject.SetActive(false);
        }
        
    }
}
