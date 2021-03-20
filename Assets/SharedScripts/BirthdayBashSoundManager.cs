using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirthdayBashSoundManager : MonoBehaviour
{
    public static int confirm = 0;
    public static int typeClip = 6;
    public AudioClip[] audioClips;
    //public AudioSource audioSrc;
    public AudioSource congratsSrc;
    //private int clapsIndex = 4;
    //private int fireworksIndex = 5;


    AudioClip RandomClip()
    {
      int rando = Random.Range(0, 3);

      if (rando >= 0 && rando < audioClips.Length)
        return audioClips[rando];
        //return audioClips[Random.Range(0, 3)];

      return null;
    }

    // Update is called once per frame
    void Update()
    {
      if (confirm == 1)
      {
        playClaps();
      }

      confirm = 0;
    }

    // Play audio that designates the congrats message.
    public void playClaps()
    {
      if (typeClip < audioClips.Length && typeClip >= 0)
        congratsSrc.PlayOneShot(audioClips[typeClip]);
    }

    public void playWrong()
    {
      int rando = Random.Range(7, 9);

      if (rando < audioClips.Length && rando >= 0)
        congratsSrc.PlayOneShot(audioClips[rando]);
    }
  }
