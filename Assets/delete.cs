using UnityEngine;

public class delete : MonoBehaviour
{
    public GameObject parent1;
    public GameObject parent2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void remove()
    {
        if (parent1.transform.childCount > 0)
        {
            Destroy(parent1.transform.GetChild(0).gameObject);
        }

        if (parent2.transform.childCount > 0)
        {
            Destroy(parent2.transform.GetChild(0).gameObject);
        }
    }
}
