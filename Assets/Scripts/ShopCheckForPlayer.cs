using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopCheckForPlayer : MonoBehaviour
{
   [SerializeField] TMP_Text Hint;
     private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag=="Player"){
           Manager.ActiveShop();
           Hint.SetText("Press 'B' to open shop menu");
         
        }
    }
    private void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag=="Player"){
           Manager.DeactivatedShop();
           Hint.SetText("");
        }
    }
}
