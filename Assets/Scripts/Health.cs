using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
     private GameUI ui;
   
    [SerializeField] Canvas UICanvas;
     public int startHealth=100;
   public int currentHealth;
   void Start(){
    currentHealth=startHealth;
     ui=UICanvas.GetComponent<GameUI>();
   }
   public void DealDamage(int damage){
        currentHealth=currentHealth-damage;  
   }
   void Death(){
        if(currentHealth<=0){
           FindObjectOfType<AudioManager>().SwitchSound(AudioManager.SoundState.Die);
            ui.Dead();
        }
   }
     //void PrintHealth(){
     //  print(currentHealth);
     //  }
   void FixedUpdate(){
        Death();
        //PrintHealth();
   }
   
}
