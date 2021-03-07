using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject settingsButton;
    //public GameObject speedTracker;
      // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Esc"))
        {
            // sets options menu to active and sets game objects back to active when closing the options menu
            if(optionsMenu.activeSelf)
            {
                optionsMenu.SetActive(false);
                settingsButton.SetActive(true);
                //speedTracker.SetActive(true);
            }
            
            // sets options menu to inactive and sets game objects to inactive when opening the options menu
            else
            {
                optionsMenu.SetActive(true);
                settingsButton.SetActive(false);
                //speedTracker.SetActive(false);
            }
        }
        
    }
}
