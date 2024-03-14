using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarTrigger : MonoBehaviour
{
   CharacterControl playerMove;
   Rigidbody2D thisCar;
   [SerializeField] TMP_Text Hint;
   void Start(){
        playerMove=GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
        thisCar=GetComponent<Rigidbody2D>();
   }
    private void OnTriggerEnter2D(Collider2D col){
        
        if(col.gameObject.tag=="Player"){
            Manager.ActiveCar();
            Hint.SetText("Press 'F' to enter the car ");
            if(playerMove.myState!=CharacterControl.CharacterState.Driving){
            playerMove.Car=this.transform;
            playerMove.carBody=thisCar;
            }
        }
            
    }
    private void OnTriggerExit2D(Collider2D col){
        
        if(col.gameObject.tag=="Player"){
            Manager.DeactivatedCar();
            Hint.SetText("");
        }
            
    }
    
}
