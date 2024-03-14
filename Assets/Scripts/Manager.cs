using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager : MonoBehaviour
{
     Health playerHealth;
     
     private void Awake(){
        DontDestroyOnLoad(gameObject);
     }
     void Start(){
        playerHealth=GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        
    }
   
    public static int money=0;
    public static int score=0;
    public static bool isPlayerNearShop=false;
    public static bool isPlayerNearCar=false;
    public static bool isGunPicked=false;
    public static bool isFirstTaskCompleted=false;
    public static void PickCoin(){
        
        money=money+10;
       
    }
   public static void AddScore(int value){
        score+=value;
   }
    public void PickMedicine(){
        if(playerHealth.currentHealth>=100){
        playerHealth.DealDamage(0);
        }
        else{
            playerHealth.DealDamage(-10);
        }
    }
    public static void CheckCurrentGoal(){
        if(score>=40){
            isFirstTaskCompleted=true;
        }
    }
    public static void PickGun(){
        isGunPicked=true;
    }
    public static void DropGun(){
        isGunPicked=false;
    }
    public static void ActiveShop(){
        isPlayerNearShop=true;
    }
    public static void ActiveCar(){
        isPlayerNearCar=true;
    }
    public static void DeactivatedShop(){
        isPlayerNearShop=false;
    }
    public static void DeactivatedCar(){
        isPlayerNearCar=false;
    }
    void Update(){
       CheckCurrentGoal();
    }
}
