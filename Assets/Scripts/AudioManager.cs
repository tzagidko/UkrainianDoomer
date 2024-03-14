using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum SoundState{Punch, PickUp, Enemy, Die, Shoot, noSound};
    public SoundState currentState;
    public AudioClip punchFX;
    public AudioClip pickupFX;
    public AudioClip enemyFX;
    public AudioClip dieFX;
    public AudioClip gunShot;
    [SerializeField] GameObject soundObj;
    [SerializeField] Transform playerObj;
    [SerializeField] float volume =0.3f;
    AudioSource objSource;
    void Start(){
        objSource=soundObj.GetComponent<AudioSource>();
        currentState=SoundState.noSound;
    }
    public void SwitchSound(SoundState newState){
        currentState=newState;
        switch(currentState){
            case SoundState.Punch:
            objSource.clip=punchFX;
            Instantiate(soundObj, playerObj.position, Quaternion.identity);
            
            objSource.Play();
            objSource.volume=volume;
            break;
            case SoundState.PickUp:
            objSource.clip=pickupFX;
            Instantiate(soundObj, playerObj.position, Quaternion.identity);
            
            objSource.Play();
            objSource.volume=volume;
            break;
             case SoundState.Enemy:
             objSource.clip=enemyFX;
            Instantiate(soundObj, playerObj.position, Quaternion.identity);
           
            objSource.Play();
            objSource.volume=volume;
            break;
             case SoundState.Die:
             objSource.clip=dieFX;
            Instantiate(soundObj, playerObj.position, Quaternion.identity);
           
            objSource.Play();
            objSource.volume=volume;
            break;
            case SoundState.Shoot:
             objSource.clip=gunShot;
            Instantiate(soundObj, playerObj.position, Quaternion.identity);
           
            objSource.Play();
            objSource.volume=volume;
            break;
        }



    }

}
