using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public LayerMask enemyLayer;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] float meleeRange= 1f;
    public GameObject attackPoint;
    private Animator myAnim;
    private CharacterControl playerMove;
    [SerializeField] GameObject AudioManagerObject;
    AudioManager audioManager;
    
    Inventory inv;

    void Start(){
      inv=GetComponent<Inventory>();
      playerMove=GetComponent<CharacterControl>();
      myAnim=GetComponent<Animator>();
      audioManager=AudioManagerObject.GetComponent<AudioManager>();
    }
    
    
    void FixedUpdate(){
         WheelInput();
         WeaponChange();
        
    }
    void WheelInput(){
      if(Input.GetAxis("Mouse ScrollWheel") > 0f){
           inv.ChangeSlot();
       }
       if(Input.GetAxis("Mouse ScrollWheel") < 0f){
           inv.ChangeSlot();
        }
       //if(Input.GetKeyDown(KeyCode.Q)){
       //   inv.ChangeSlot();
      //
      // }
    }
    void WeaponChange(){
      if(playerMove.myState==CharacterControl.CharacterState.OnFoot){
      if(Inventory.currentSlot==Inventory.fistSlot){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
          myAnim.SetBool("Attack", true);
          MeleeAttack();
          audioManager.SwitchSound(AudioManager.SoundState.Punch);
          Debug.Log("Punch");
        }
      }
      else if(Inventory.currentSlot==Inventory.pistolSlot){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
          ShootAttack();
          audioManager.SwitchSound(AudioManager.SoundState.Shoot);
          Debug.Log("Shot");
        }
      }    
      } 
    }
    void MeleeAttack(){
      Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.transform.position, meleeRange, enemyLayer);
      foreach(Collider2D enemy in hitEnemies){
        enemy.GetComponent<EnemyHealth>().DealDamage(30);
        
      }
    }
    void ShootAttack(){
      
      Instantiate(bullet, firePoint.position, gameObject.transform.rotation);//create ebullet
     

    }
    void OnDrawGizmos(){
        if(attackPoint==null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.transform.position, meleeRange);
    }
}
