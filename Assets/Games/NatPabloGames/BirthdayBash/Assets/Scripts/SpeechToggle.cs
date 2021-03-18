using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeechToggle : MonoBehaviour
{
  public Image speechBubble;
  public TextMeshProUGUI speechText;

  public void ToggleText()
  {
    if (speechText.enabled == true)
    {
      speechText.enabled = false;
      speechBubble.enabled = false;
    }
    else
    {
      speechText.enabled = true;
      speechBubble.enabled = true;
    }
  }
}
