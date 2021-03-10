using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicVolumeManager : MonoBehaviour
{
    public AudioMixer musicVolume;
    public AudioMixer gameVolume;

    public void SetMusicVolume(float volume)
    {
        musicVolume.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetGameVolume(float volume)
    {
        gameVolume.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }
}
