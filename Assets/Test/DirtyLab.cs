using UnityEngine;

public class DirtyLab : MonoBehaviour
{
    int num = 0;
    public GameObject lab;
    public GameObject dial;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(num >= 4)
        {
            lab.SetActive(true);
           //dial.SetActive(true);
            gameObject.SetActive(false);
           
          
        }
    }

    public void AddNumber()
    {
        num += 1;
    }
}
