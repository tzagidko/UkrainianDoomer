using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
     public int startHealth=100;
   public int currentHealth;
   void Start(){
    currentHealth=startHealth;
   }
   public void DealDamage(int damage){
        currentHealth=currentHealth-damage;  
   }
   void Death(){
        if(currentHealth<=0){
               Manager.AddScore(20);
            Destroy(this.gameObject);
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
