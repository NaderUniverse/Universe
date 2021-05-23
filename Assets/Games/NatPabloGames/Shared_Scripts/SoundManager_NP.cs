using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_NP : MonoBehaviour
{
    public const int Marvelous = 0;
    public const int Congratulations = 1;
    public const int Yes = 2;
    public const int GreatJob = 3;
    public const int GreatWork = 4;
    public const int GoodJob = 5;
    public const int Congrats = 6;

    public static int confirm = 0;
    public static int typeClip;

    public AudioClip[] audioClips;
    public AudioSource congratsSrc;

    // Update is called once per frame
    void Update()
    {
      if (confirm == 1)
      {
        PlayCongrats();
      }

      confirm = 0;
    }

    // Play audio that designates the congrats message.
    public void PlayCongrats()
    {
      if (typeClip < audioClips.Length && typeClip >= 0)
        congratsSrc.PlayOneShot(audioClips[typeClip]);
    }
  }
