using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveMainMenu : MonoBehaviour
{
    public void MoveBack()
    {
        SceneManager.LoadScene(0);
    }
}
