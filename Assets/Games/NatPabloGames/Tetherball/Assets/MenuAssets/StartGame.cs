using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
  //public Animator transition;
  public float transitionTime = 1f;
  private const int gameOne = 1;
  private const int gameTwo = 2;
  private const int gameThree = 3;


  public void PlayGame ()
  { //int level = SceneManager.GetActiveScene().buildIndex + 1;
    //StartCoroutine(Load(gameOne));
    SceneManager.LoadScene(gameOne);
  }

  public void PlayGameTwo ()
  { //int level = SceneManager.GetActiveScene().buildIndex + 1;
    //StartCoroutine(Load(gameTwo));
    SceneManager.LoadScene(gameTwo);
  }

  public void PlayGameThree ()
  { //int level = SceneManager.GetActiveScene().buildIndex + 1;
    //StartCoroutine(Load(gameThree));
    SceneManager.LoadScene(gameThree);
  }


  IEnumerator Load(int levelIndex)
  {
    //transition.SetTrigger("Start");

    yield return new WaitForSeconds(transitionTime);

    SceneManager.LoadScene(levelIndex);

  }
}
