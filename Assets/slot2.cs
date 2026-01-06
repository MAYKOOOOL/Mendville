using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class slot2 : MonoBehaviour, IDropHandler
{
    [SerializeField] private TMP_Text gene1Text;
    [SerializeField] private TMP_Text gene2Text;

    public Scriptable assignedScriptable;
    public bool isFilled = false;
    public GameObject hand;
    public GameObject hand1;
   private SetDialogue dial;
   public GameObject open;
     public Button but;
   public Button but1;
   public Button but2;
    public Button but3;
    public Button but4;
    public Button but5;
   public Button but6;
    public Button but7;
    public Button but8;
    private hold hawak;
        public bool pangcheck;
    

    public slot3 slot;
    public void OnDrop(PointerEventData eventData)
    {
        if (isFilled){
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
       

        
    }

    private void Update()
    {

     

        if (transform.childCount == 0 )
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
          if (isFilled == true)
        {
            hand.SetActive(false);
            hand1.SetActive(false);



        }
        if (isFilled && slot.isFilled)
        {
            open.SetActive(true);
        }



        if (!isFilled && slot.isFilled || !isFilled && slot.isFilled == false || isFilled && slot.isFilled == false){
            but1.interactable = true;
            but2.interactable = true;
            but3.interactable = true; 
            but4.interactable = true;     
            but.interactable = true;
            but5.interactable = true;
            but6.interactable = true;
            but7.interactable = true; 
            but8.interactable = true;  
            slot.but1.interactable = true;
            slot.but2.interactable = true;
            slot.but3.interactable = true; 
            slot.but4.interactable = true;     
            slot.but.interactable = true;
            slot.but5.interactable = true;
            slot.but6.interactable = true;
            slot.but7.interactable = true; 
            slot.but8.interactable = true;         
        }
          if(isFilled && slot.isFilled == false || isFilled && slot.isFilled || !isFilled && slot.isFilled){

            but.interactable = false;
            but1.interactable = false;
            but2.interactable = false;
            but3.interactable = false;
            but4.interactable = false;
            but5.interactable = false;
            but6.interactable = false;
            but7.interactable = false;
            but8.interactable = false;
            slot.but.interactable = false;
            slot.but1.interactable = false;
            slot.but2.interactable = false;
            slot.but3.interactable = false;
            slot.but4.interactable = false;
            slot.but5.interactable = false;
            slot.but6.interactable = false;
            slot.but7.interactable = false;
            slot.but8.interactable = false;
           
        }

       

         
    }
}
