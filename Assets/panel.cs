using UnityEngine;
using UnityEngine.UI;

public class panel : MonoBehaviour
{
    [Header("Panel to Activate/Deactivate")]
    public Button but;
    public Button but1;

    [Header("GameObjects with Slot script attached")]
    public GameObject slot1Object;
    public GameObject slot2Object;

    private slot2 slot1;
    private slot2 slot2;

    private void Start()
    {
        
        if (slot1Object != null){
            slot1 = slot1Object.GetComponent<slot2>();
    }
        if (slot2Object != null){
            slot2 = slot2Object.GetComponent<slot2>();
        }
    }

    private void Update()
    {
       
        if (slot1.isFilled == true || slot2.isFilled == true)
        {
           but.enabled = false;
           but1.enabled = false;
        }else{
            but.enabled = true;
            but1.enabled = true;
    }
    }
}
