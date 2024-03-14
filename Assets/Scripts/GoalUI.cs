using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GoalUI : MonoBehaviour
{
     public TMP_Text output;
   

    void FixedUpdate(){
        SetText();
    }
    void SetText(){
        if(!Manager.isFirstTaskCompleted){
        output.SetText("Current goal: "+ "gain 40 XP");
        }
        if(Manager.isFirstTaskCompleted){
            output.SetText("Current goal: "+ "collect 40 coins and buy a trophy");
        }
    }
}
