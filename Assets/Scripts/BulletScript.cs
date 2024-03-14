using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D bulRb;
     [SerializeField] private float flightSpeed;
     [SerializeField] int bulletDamage; //setup bullet damage
   
    // Start is called before the first frame update
    void Start()
    {
        
        
        StartCoroutine(Wait());//delay 
         bulRb=GetComponent<Rigidbody2D>();
        bulRb.velocity=transform.up*flightSpeed;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Enemy") {//checking for enemy
             col.gameObject.GetComponent<EnemyHealth>().DealDamage(bulletDamage);// enemy takes damage
         
           Destroy(gameObject);//bullet destroys
        }
    }
     IEnumerator Wait(){
        yield return new WaitForSeconds(6);
        Destroy(gameObject); //destroy bullet after 15 seconds
    }
   
}
