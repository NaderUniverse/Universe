using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraTest : MonoBehaviour
{
    public GameObject Game;
    public GameObject main;

    public Button Test;
    
    // Start is called before the first frame update
    void Start()
    {
        Test.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void TaskOnClick()
    {
        
        Game.SetActive(false);
        main.SetActive(true);
    }
}
