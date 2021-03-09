using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject settingsButton;

    void Update()
    {
        if(Input.GetButtonDown("Esc"))
        {
            // sets options menu to active and sets game objects back to active when closing the options menu
            if(settingsMenu.activeSelf)
            {
                settingsMenu.SetActive(false);
                settingsButton.SetActive(true);
            }
            
            // sets options menu to inactive and sets game objects to inactive when opening the options menu
            else
            {
                settingsMenu.SetActive(true);
                settingsButton.SetActive(false);
            }
        }
        
    }
}
