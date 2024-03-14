using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
     public TMP_Text output;
   

    void FixedUpdate(){
        SetText();
    }
    void SetText(){
        output.SetText("Score: "+Manager.score);
    }
}
