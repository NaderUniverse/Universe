using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
public ButtonSound button;

 
    public void MoveOneScene(){
     // LoadNextLevel();
     
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   
    }

     public void MoveThreeScene(){
     // LoadNextLevel();
     
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
   
    }
     /* void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
*/
   /* IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        transition.SetTrigger("Start");
        //wait for it to stop
        yield return new WaitForSeconds(1f); //pauses coroutine for 1 second

        SceneManager.LoadScene(levelIndex);
    }
    */
    public void QuitGame(){
        Debug.Log("You have quit the game!");
        Application.Quit();
    }
}
