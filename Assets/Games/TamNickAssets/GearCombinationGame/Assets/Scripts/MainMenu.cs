using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
public ButtonSound button;

 
    public void PlayGame(){
     // LoadNextLevel();
     
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   
    }
     
    public void QuitGame(){
        Debug.Log("You have quit the game!");
        Application.Quit();
    }
}
