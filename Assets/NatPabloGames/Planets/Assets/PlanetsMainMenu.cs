﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetsMainMenu : MonoBehaviour
{
  public Animator transition;
  public float transitionTime = 1f;

  public void PlayGame ()
  {
    StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
  }

  public void QuitGame ()
  {
    Application.Quit();
  }

  IEnumerator Load(int levelIndex)
  {
    transition.SetTrigger("Start");

    yield return new WaitForSeconds(transitionTime);

    SceneManager.LoadScene(levelIndex);

  }
}