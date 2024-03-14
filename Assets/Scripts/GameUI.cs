using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour
{
   public enum GameState{MainMenu, Playing, Paused, Shopping, Completed, Dead};
   public GameState currentState;
   public GameObject PausedPanel, DeadPanel, ShopPanel, CompletedPanel;
   private void Awake(){
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            CheckGameState(GameState.Playing);
        }
        else
        {
            CheckGameState(GameState.Playing);

        }
   }
     public void CheckGameState(GameState newGameState)
    {
        currentState = newGameState;
        switch (currentState)
        {
            case GameState.MainMenu:
                MainMenuSetup();
                break;
            case GameState.Paused:
                GamePaused();
              
              Time.timeScale = 0f;
               break;
            case GameState.Playing:
                GameActive();
               
                Time.timeScale = 1f;
                break;
            case GameState.Dead:
                GameDead();
                Time.timeScale = 0f;
                break;
            case GameState.Shopping:
                GameShopping();
                Time.timeScale=1f;
             break;
            case GameState.Completed:
            GameCompleted();
            Time.timeScale=0f;
            break;

        }
    }
     public void MainMenuSetup()
    {
       
       SceneManager.LoadScene("MainMenu");
    }

    public void GameActive()
    {
       
       
        PausedPanel.SetActive(false);
        DeadPanel.SetActive(false);
        ShopPanel.SetActive(false);
        CompletedPanel.SetActive(false);
       
    }

    public void GamePaused()
    {
       
       
        PausedPanel.SetActive(true);
        DeadPanel.SetActive(false);
        ShopPanel.SetActive(false);
        CompletedPanel.SetActive(false);
        
    }
    public void GameShopping(){
        PausedPanel.SetActive(false);
        DeadPanel.SetActive(false);
        ShopPanel.SetActive(true);
        CompletedPanel.SetActive(false);
    }

    public void GameDead()
    {
       
        
        PausedPanel.SetActive(false);
        DeadPanel.SetActive(true);
        ShopPanel.SetActive(false);
        CompletedPanel.SetActive(false);
        Time.timeScale=0f;
    }
    public void GameCompleted(){
        PausedPanel.SetActive(false);
        DeadPanel.SetActive(false);
        ShopPanel.SetActive(false);
        CompletedPanel.SetActive(true);
    }
    public void Pause(){
   
        CheckGameState(GameState.Paused);

   }
   public void Resume(){
        CheckGameState(GameState.Playing);
   }
   public void Dead(){
        CheckGameState(GameState.Dead);
   }
   public void OpenShop(){
        CheckGameState(GameState.Shopping);
   }
   public void Complete(){
        CheckGameState(GameState.Completed);
        Manager.money=0;
        Manager.score=0;
   }
   
}
