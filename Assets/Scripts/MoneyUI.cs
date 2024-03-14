using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TMP_Text output;
   

    void FixedUpdate(){
        SetText();
    }
    void SetText(){
        output.SetText("Money: "+Manager.money);
    }
}
