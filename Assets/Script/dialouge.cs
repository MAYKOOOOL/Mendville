using System.Collections;
using UnityEngine;
using TMPro;

public class dialouge : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] dia;
    public float speed;

    private int i;
    private bool isTyping;

    void Start()
    {
        text.text = "";
        Talk();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isTyping && text.text == dia[i])
            {
                Next();
            }
            else if (isTyping)
            {
                StopAllCoroutines();
                text.text = dia[i];
                isTyping = false;
            }
        }
    }

    void Talk()
    {
        i = 0;
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        isTyping = true;
        text.text = "";

        foreach (char c in dia[i])
        {
            text.text += c;
            yield return new WaitForSeconds(speed);
        }

        isTyping = false;
    }

    void Next()
    {
        if (i < dia.Length - 1)
        {
            i++;
            StartCoroutine(Type());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
