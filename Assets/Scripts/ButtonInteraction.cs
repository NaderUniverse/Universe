using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public GameObject text;
    public GameObject playMenuText;
    public GameObject wantToPlayMenu;
    public GameObject gameIndex;
    // Start is called before the first frame update
    
    void OnTriggerStay2D(Collider2D info)
    {
        Debug.Log("DEES\n");
        if(info.gameObject.tag == "HitTheBrakesInteraction")
        {
            gameIndex.GetComponent<NextScene>().index = 1;
            Debug.Log("DEEZ\n");
            text.SetActive(true);

            if(Input.GetButton("Interact"))
            {
                wantToPlayMenu.SetActive(true);
            }
        }

        else if(info.gameObject.tag == "PlanetInteraction")
        {
            gameIndex.GetComponent<NextScene>().index = 7;
            text.SetActive(true);

            if(Input.GetButton("Interact"))
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
