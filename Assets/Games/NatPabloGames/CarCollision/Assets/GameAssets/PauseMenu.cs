using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    private int mainMenuIndex = 0;
    public AudioSource typewriter;

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
      typewriter.Play();
    }

    void Pause()
    {
      Time.timeScale = 0f;
      gameIsPaused =  true;
      typewriter.Stop();
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
