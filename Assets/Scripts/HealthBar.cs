using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {   
        playerHealth=GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();//finding player health
        healthSlider=GetComponent<Slider>();
        healthSlider.maxValue=playerHealth.startHealth;
        
        
        
    }
    void FixedUpdate(){
        healthSlider.value=playerHealth.currentHealth;//making value in health bar equal to our current health
    }

    //void SetHealth(int hp){
    //    healthSlider.value=hp;
    // }
}
