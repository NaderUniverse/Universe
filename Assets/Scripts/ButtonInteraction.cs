using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public GameObject text;
    public GameObject playMenuText;
    public GameObject wantToPlayMenu;
    public GameObject ChangeScene;

    void OnTriggerStay2D(Collider2D info)
    {
        Debug.Log("DEES\n");
        if (info.gameObject.CompareTag("HitTheBrakesInteraction"))
        {
            ChangeScene.GetComponent<ChangeScene>().index = 1;
            Debug.Log("DEEZ\n");
            text.SetActive(true);

            if (Input.GetButton("Interact"))
            {
                wantToPlayMenu.SetActive(true);
            }
        }

        else if (info.gameObject.CompareTag("PlanetInteraction"))
        {
            ChangeScene.GetComponent<ChangeScene>().index = 7;
            text.SetActive(true);

            if (Input.GetButton("Interact"))
            {
                wantToPlayMenu.SetActive(true);
            }
        }

        else if (info.gameObject.CompareTag("TetherballInteraction"))
        {
            ChangeScene.GetComponent<ChangeScene>().index = 9;
            text.SetActive(true);

            if (Input.GetButton("Interact"))
            {
                wantToPlayMenu.SetActive(true);
            }
        }
        else if (info.gameObject.CompareTag("GearComboInteraction"))
        {
            ChangeScene.GetComponent<ChangeScene>().index = 16;
            text.SetActive(true);

            if (Input.GetButton("Interact"))
            {
                wantToPlayMenu.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D info)
    {
        text.SetActive(false);
        wantToPlayMenu.SetActive(false);
    }
}
