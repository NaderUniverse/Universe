using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSound : MonoBehaviour
{
    public AudioSource type;

    public void playAudio()
    {
        type.Play();
    }
}
