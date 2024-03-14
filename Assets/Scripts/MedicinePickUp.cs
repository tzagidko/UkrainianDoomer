using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicinePickUp : MonoBehaviour
{
     GameObject EmptyObj;
     Manager manager;
    void Start(){
        EmptyObj=GameObject.FindGameObjectWithTag("Manager");
        manager=EmptyObj.GetComponent<Manager>();
      
     }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag=="Player"){
            Destroy(this.gameObject);
            manager.PickMedicine();
             FindObjectOfType<AudioManager>().SwitchSound(AudioManager.SoundState.PickUp);
        }
    }
}
