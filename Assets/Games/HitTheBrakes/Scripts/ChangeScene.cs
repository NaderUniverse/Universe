using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // add whatever index you need to move to specific scene
    public int index;
    public string SceneName;
    public Animator transition;
    public float transitionTime = 1f;
    // move to next scene
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // move to specified scene, must specify index in Unity
    public void MoveIndex()
    {
        SceneManager.LoadScene(index);
    }

    public void MoveSceneName()
    {
        SceneManager.LoadScene(SceneName);
    }

    IEnumerator Load(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

}
