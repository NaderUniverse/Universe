using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }
}
