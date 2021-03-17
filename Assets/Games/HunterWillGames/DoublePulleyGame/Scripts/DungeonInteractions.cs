using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonInteractions : MonoBehaviour
{
    public GameObject hintText;
    public GameObject userInteractText;

    void OnTriggerStay2D(Collider2D info)
    {
        if (info.gameObject.CompareTag("WisemanHint"))
        {
            userInteractText.SetActive(true);

            if(Input.GetButton("Interact"))
            {
                hintText.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D info)
    {
        userInteractText.SetActive(false);
        //hintText.SetActive(false);
    }
}
