using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopping : MonoBehaviour
{
    [SerializeField] GameObject medicine, magicKit;
    [SerializeField] GameObject shop;
    GameUI ui;
    [SerializeField] private Canvas canv;
    void Start(){
        ui=canv.GetComponent<GameUI>();
    }
    void FixedUpdate(){
       GoToShop();
    }
    void GoToShop(){
         if(Manager.isPlayerNearShop&&Input.GetKeyDown(KeyCode.B)){
            
            if(ui.currentState==GameUI.GameState.Playing){
            ui.OpenShop();
            }
            else if(ui.currentState==GameUI.GameState.Paused){
            ui.Resume();
            
            }
            /*if(Manager.money>=20){
                Instantiate(medicine, gameObject.transform.position+new Vector3(0,-2,0), Quaternion.identity);
                Manager.money=Manager.money-20;
            }*/
        }
    }
    public void BuyMedicine(){
        if(Manager.money>=20){
                Instantiate(medicine, shop.transform.position+new Vector3(2,-2,0), Quaternion.identity);
                Manager.money=Manager.money-20;
            }
    }
    public void BuyMagicKit(){
         if(Manager.money>=40){
                Instantiate(magicKit, shop.transform.position+new Vector3(2,-2,0), Quaternion.identity);
                Manager.money=Manager.money-40;
            }
    }
}
