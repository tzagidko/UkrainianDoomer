using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    [SerializeField] Sprite fistImg, pistolImg;
    private Sprite startImg;
    public static Sprite currentImg;
    public static int  currentSlot;
    [SerializeField] int startSlot=0; 
    public static int fistSlot=0;
    public static int pistolSlot=1;
    
    void Start()
    {
        startImg=fistImg;
        currentSlot=startSlot;
        currentImg=startImg;
        
    }
    public void ChangeSlot(){
        if(Manager.isGunPicked){
            if(currentSlot==fistSlot){
            currentSlot=pistolSlot;
            currentImg=pistolImg;
             }
            else if(currentSlot==pistolSlot){
            currentSlot=fistSlot;  
            currentImg=fistImg;

            }
            else{
            currentSlot=fistSlot;
            currentImg=fistImg;
             }
        }
        else{
            currentSlot=fistSlot;
            currentImg=fistImg;
        }
        
    }
    
   
}