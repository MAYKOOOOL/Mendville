using UnityEngine;

public class taram : MonoBehaviour
{
    public slot2 slot;
    public slot3 slot1;
    public GameObject ulay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(slot.isFilled && slot1.isFilled)
        {
            ulay.SetActive(true);
        }
    }
}
