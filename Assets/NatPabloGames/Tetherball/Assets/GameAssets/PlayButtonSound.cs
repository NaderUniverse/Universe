using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonSound : MonoBehaviour
{
  public AudioSource button;

  public void playAudio()
  {
      button.Play();
  }
}
