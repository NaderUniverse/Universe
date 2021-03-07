using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplauseSound : MonoBehaviour
{
    public AudioSource applause;

    public void playSound()
     {
        applause.Play();
     }
}
