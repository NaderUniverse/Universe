using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource button;

    public void playAudio()
    {
        button.Play();
    }
}
