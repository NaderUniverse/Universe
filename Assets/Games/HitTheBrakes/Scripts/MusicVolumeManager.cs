using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicVolumeManager : MonoBehaviour
{
   public AudioMixer musicMixer;
   public void setMusicVolume(float musicVolume)
   {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
   }
}
