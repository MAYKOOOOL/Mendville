using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class slot3 : MonoBehaviour, IDropHandler
{
    [SerializeField] private TMP_Text gene1Text;
    [SerializeField] private TMP_Text gene2Text;

    public Scriptable assignedScriptable;
    public bool isFilled = false;
    public GameObject hand;
    public GameObject hand1;
   private SetDialogue dial;
   public Button but;
   public Button but1;
   public Button but2;
    public Button but3;
    public Button but4;
     public Button but5;
   public Button but6;
    public Button but7;
    public Button but8;
    public slot2 slot;
    private hold hawak;
    public void OnDrop(PointerEventData eventData)
    {
        if (isFilled)
        {

            return;
        }

        GameObject dropped = eventData.pointerDrag;
        if (dropped == null) return;

        drag dragComponent = dropped.GetComponent<drag>();
        hold holdComponent = dropped.GetComponent<hold>();
        hawak = holdComponent;
        if (dragComponent != null && !isFilled)
        {
            dragComponent.parentAfter = transform;
        }

        if (holdComponent != null && holdComponent.geneData != null && !isFilled)
        {
            assignedScriptable = holdComponent.geneData;
            gene1Text.text = assignedScriptable.gene1;
            gene2Text.text = assignedScriptable.gene2;
            isFilled = true;
        }
        if (isFilled == true)
        {
            hand.SetActive(false);
            hand1.SetActive(true);

        }
        
    }
    

    public void check()
    {
        if (transform.childCount == 0)
        {
            assignedScriptable = null;
            gene1Text.text = "";
            gene2Text.text = "";
            isFilled = false;
        }
        else
        {
            assignedScriptable = hawak.geneData;
            gene1Text.text = assignedScriptable.gene1;
            gene2Text.text = assignedScriptable.gene2;
            isFilled = true;
        }
    }

    private void Update()
    {
        check();
        //  if(!isFilled && slot.isFilled || !isFilled && slot.isFilled == false){
        //     but1.interactable = true;
        //     but2.interactable = true;
        //     but3.interactable = true; 
        //     but4.interactable = true;     
        //     but.interactable = true;        
        // }
        // if(isFilled && slot.isFilled == false || isFilled && slot.isFilled){

        //     but.interactable = false;
        //     but1.interactable = false;
        //     but2.interactable = false;
        //     but3.interactable = false;
        //     but4.interactable = false;
           
        // }
       
    


}
}
