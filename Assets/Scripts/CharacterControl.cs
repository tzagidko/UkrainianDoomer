using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterControl : MonoBehaviour
{
    public enum CharacterState{OnFoot, Driving};
    public CharacterState myState;
    private Animator myAnim;
    public Transform Car;
    [SerializeField] float moveSpeed, boostSpeed, carSpeed;
    [SerializeField] private float rotationSpeed, playerRotationSpeed;
    private float xPos, yPos;
    private Rigidbody2D body;
    public Rigidbody2D carBody;
    [SerializeField] TMP_Text Hint;
   
    private GameUI ui;
    
    [SerializeField] Canvas UICanvas;
   
    private Vector2 move;
    [SerializeField]private GameObject footsteps,carEngine;
   
   
    // Start is called before the first frame update
    void Start()
    {
        body= GetComponent<Rigidbody2D>();
        carBody=Car.GetComponent<Rigidbody2D>();
        myAnim=GetComponent<Animator>();
        ui=UICanvas.GetComponent<GameUI>();
        footsteps.SetActive(false);
        carEngine.SetActive(false);
        myState=CharacterState.OnFoot;
    }
    void CheckForCurrentPlayerState(CharacterState newState){
        myState=newState;
        switch(newState)
        {
            case CharacterState.OnFoot:
             GetPosition();
            Move();
    
            break;
              
            case CharacterState.Driving:
            
            gameObject.transform.position=Car.position;
            Hint.SetText("Press 'E' to exit the car");
           
          
            
            GetPosition();
            CarMove();
              
            
            
            break;
        }
    }
    void CheckForGettingIntoCar(){
        if(Manager.isPlayerNearCar&&Input.GetKeyDown(KeyCode.F)){
            myState=CharacterState.Driving;
             footsteps.SetActive(false);
           
           
        }
    }
    void GettingOutOfTheCar(){
        if(myState==CharacterState.Driving&&Input.GetKeyDown(KeyCode.E)){
            gameObject.transform.position=Car.position+new Vector3(-3,0,0);
            gameObject.transform.rotation=Quaternion.identity;
            myState=CharacterState.OnFoot;
            Hint.SetText("");
            carEngine.SetActive(false);
            

        }
    }

    // Update is called once per frame
    void Update()
    {

       CheckForCurrentPlayerState(myState);
       CheckForGettingIntoCar();
        GettingOutOfTheCar();
        CheckForPause();
        
    }
    void GetPosition(){
        xPos=Input.GetAxis("Horizontal");
        yPos=Input.GetAxis("Vertical");
    }
    void Move(){
      
      if(Input.GetKey(KeyCode.LeftShift)){
        body.velocity=new Vector2 (xPos*(moveSpeed+boostSpeed), yPos*(moveSpeed+boostSpeed));
        if(body.velocity!=Vector2.zero){
            Quaternion toRotation=Quaternion.LookRotation(Vector3.forward, body.velocity);
            transform.rotation=Quaternion.RotateTowards(transform.rotation,toRotation,playerRotationSpeed*Time.deltaTime);
            SetMovingAnim();
            footsteps.SetActive(true);
             
            
           
        }
         else if(body.velocity==Vector2.zero){
            SetIdleAnim();
           footsteps.SetActive(false);
         }
       }
       else{
        body.velocity=new Vector2 (xPos*moveSpeed, yPos*moveSpeed);
        if(body.velocity!=Vector2.zero){
            Quaternion toRotation=Quaternion.LookRotation(Vector3.forward, body.velocity);
            transform.rotation=Quaternion.RotateTowards(transform.rotation,toRotation,playerRotationSpeed*Time.deltaTime);
            SetMovingAnim();
            footsteps.SetActive(true);
             
        }
         else if(body.velocity==Vector2.zero){
            SetIdleAnim();
            footsteps.SetActive(false);
             
         }
       }

    }
    void CarMove(){
      
       if(Input.GetKey(KeyCode.LeftShift)){
        carBody.velocity=new Vector2 (xPos*(carSpeed+boostSpeed), yPos*(carSpeed+boostSpeed));
        if(carBody.velocity!=Vector2.zero){
            Quaternion toRotation=Quaternion.LookRotation(Vector3.forward, carBody.velocity);
            Car.transform.rotation=Quaternion.RotateTowards(Car.transform.rotation,toRotation,rotationSpeed*Time.deltaTime);
            carEngine.SetActive(true);
            gameObject.transform.rotation=Quaternion.RotateTowards(Car.transform.rotation,toRotation,rotationSpeed*Time.deltaTime);
        }
        
       }
       else{
         carBody.velocity=new Vector2 (xPos*carSpeed, yPos*carSpeed);
         if(carBody.velocity!=Vector2.zero){
            Quaternion toRotation=Quaternion.LookRotation(Vector3.forward, carBody.velocity);
            Car.transform.rotation=Quaternion.RotateTowards(Car.transform.rotation,toRotation,rotationSpeed*Time.deltaTime);
           carEngine.SetActive(true);
            gameObject.transform.rotation=Quaternion.RotateTowards(Car.transform.rotation,toRotation,rotationSpeed*Time.deltaTime);
        }
         else if(carBody.velocity==Vector2.zero){
            
             carEngine.SetActive(false);
         }
         
       }
       

    }
    void SetIdleAnim(){
        myAnim.SetBool("Idle", true);
        myAnim.SetBool("Walk", false);
        myAnim.SetBool("Attack", false);
    }
    void SetMovingAnim(){
        myAnim.SetBool("Idle", false);
        myAnim.SetBool("Walk", true);
        myAnim.SetBool("Attack", false);
    }
    void CheckForPause(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(ui.currentState==GameUI.GameState.Playing){
            ui.Pause();
            }
            else if(ui.currentState==GameUI.GameState.Paused){
            ui.Resume();
            }
        }
    }
   
    
}
