using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip hover;
    public AudioClip click;


    public void HoverSound(){
        sound.PlayOneShot(hover);
    }

    public void ClickSound(){
        sound.PlayOneShot(click);
    }
}
