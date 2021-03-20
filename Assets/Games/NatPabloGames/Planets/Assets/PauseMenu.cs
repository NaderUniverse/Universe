using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


// add your typewriter and pausemenuUI in unity editor inspector 
public class PauseMenu : MonoBehaviour
{
    public static bool PausedGame = false;
    public GameObject pauseMenuUI;
    public AudioMixer audioMixer;
    public AudioSource typewriter;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          if (PausedGame)
          {
            Resume();
          }

          else
          {
            Pause();
          }
        }
    }

    public void SetVolume (float volume)
    {
      audioMixer.SetFloat("volume", volume);
    }

    public void Resume()
    {
      pauseMenuUI.SetActive(false);
      // Put speed back to normal
      Time.timeScale = 1f;
      PausedGame = false;
      typewriter.Play();
    }

    void Pause()
    {
      pauseMenuUI.SetActive(true);
      // freeze the game
      Time.timeScale = 0f;
      PausedGame = true;
      typewriter.Stop();
    }

    public void LoadMenu()
    {
      Time.timeScale = 1f;
      SceneManager.LoadScene("PlanetMenu");
      //Debug.Log ("Menu");
    }

    public void QuitGame()
    {
      Debug.Log ("Quitting");
      Application.Quit();
    }
}
