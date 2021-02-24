using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // add whatever index you need to move to specific scene
    public int index;
    // move to next scene
    public void next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // move to specified scene, must specify index in Unity
    public void move()
    {
        SceneManager.LoadScene(index);
    }
}
