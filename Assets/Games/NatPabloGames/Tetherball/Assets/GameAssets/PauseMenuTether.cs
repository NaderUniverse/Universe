using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuTether : MonoBehaviour
{
    public static bool gameIsPaused = false;
    private int mainMenuIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (gameIsPaused)
        {
          Resume();
        }

        else
        {
          Pause();
        }
    }

    public void Resume()
    {
      Time.timeScale = 1f;
      gameIsPaused = false;
    }

    void Pause()
    {
      Time.timeScale = 0f;
      gameIsPaused =  true;
    }

    public void LoadMenu()
    {
      Time.timeScale = 1f;
      SceneManager.LoadScene(mainMenuIndex);
    }

    public void QuitGame()
    {
      Debug.Log("quit");
      Application.Quit();
    }


}
