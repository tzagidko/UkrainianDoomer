using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicKitPickUp : MonoBehaviour
{
   

    // Start is called before the first frame update
   

    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag=="Player"&&Manager.isFirstTaskCompleted){
            Destroy(this.gameObject);
             FindObjectOfType<AudioManager>().SwitchSound(AudioManager.SoundState.PickUp);
             FindObjectOfType<GameUI>().Complete();
        }
    }
}
