using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    public GameObject Panel;
    public bool isPaused;

    public void OpenPanel()
    {
        if(Panel != null)
        {
            if(isPaused)
           {
           ResumeGame();
           }
           else
           {
            isPaused = true;
            Panel.SetActive(true);
            Time.timeScale = 0f;
           }
            //Panel.SetActive(true);
        }
    }

    public void ResumeGame()
    {
            isPaused = false;
            Panel.SetActive(false);
            Time.timeScale=1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
