using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsLoading : MonoBehaviour
{
   public static void LoadLevel(){
        SceneManager.LoadScene("SampleScene");
        Manager.money=0;
        Manager.score=0;
   }
   public static void QuitGame(){
         Application.Quit();
   }
}
