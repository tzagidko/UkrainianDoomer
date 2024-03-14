using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag=="Player"){
            Destroy(this.gameObject);
            Manager.PickGun();
             FindObjectOfType<AudioManager>().SwitchSound(AudioManager.SoundState.PickUp);
        }
    }
}
