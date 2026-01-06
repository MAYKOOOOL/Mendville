using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
   public checkerfoil check;
   public checkerfoil check1;

   public Button but;
   private void Update() {
    if(check.Checked && check1.Checked){
        but.interactable = true;
    }else{
         but.interactable = false;
    }
   }
}
