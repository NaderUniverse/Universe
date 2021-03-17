using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public AudioSource song;

    public void unpauseSong()
    {
        song.UnPause();
    }
    public void pauseSong()
    {
        song.Pause();
    }
}
