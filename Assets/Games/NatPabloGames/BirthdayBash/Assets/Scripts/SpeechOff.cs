using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeechOff : MonoBehaviour
{
    public Image speechBubble;
    public Image eqn;
    // Start is called before the first frame update
    void Start()
    {
        speechBubble.enabled = false;
        eqn.enabled = false;
    }

    public void ToggleText()
    {
      if (eqn.enabled == true)
      {
        eqn.enabled = false;
        speechBubble.enabled = false;
      }
      else
      {
        eqn.enabled = true;
        speechBubble.enabled = true;
      }
    }

}
