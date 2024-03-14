using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Health playerHealth;
    void Start(){
        playerHealth=GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }
    [SerializeField] int enemyDamage;
    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag=="Player"){
            playerHealth.DealDamage(enemyDamage);
             FindObjectOfType<AudioManager>().SwitchSound(AudioManager.SoundState.Enemy);
        }
    }
}
