using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTether : MonoBehaviour
{
  //public Animator transition;
  public float transitionTime = 1f;
  private int player1 = 4;
  private int player2 = 5;
  private int player3 = 6;


  public void PlayGame ()
  {
    //StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
    //StartCoroutine(Load(player1));
    SceneManager.LoadScene(player1);
    Time.timeScale = 1f;
  }

  public void PlayGameTwo ()
  {
    //StartCoroutine(Load(player2));
    SceneManager.LoadScene(player2);
    Time.timeScale = 1f;
  }

  public void PlayGameThree ()
  {
    //StartCoroutine(Load(player3));
    SceneManager.LoadScene(player3);
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
