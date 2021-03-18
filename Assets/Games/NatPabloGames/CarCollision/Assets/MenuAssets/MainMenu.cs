using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  //public Animator transition;
  public float transitionTime = 1f;


  public void PlayGame ()
  {
    //StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
    //StartCoroutine(Load(player1));
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    Time.timeScale = 1f;
  }

  public void QuitGame ()
  {
    Application.Quit();
  }

  IEnumerator Load(int levelIndex)
  {
    //transition.SetTrigger("Start");

    yield return new WaitForSeconds(transitionTime);

    SceneManager.LoadScene(levelIndex);

  }
}
