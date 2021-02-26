using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static int confirm = 0;
    public static int typeClip = 6;
    public AudioClip[] audioClips;
    public AudioSource audioSrc;
    public AudioSource congratsSrc;
    private int clapsIndex = 4;
    private int fireworksIndex = 5;


    AudioClip RandomClip()
    {
      int rando = Random.Range(0, 3);

      if (rando >= 0 && rando < audioClips.Length)
        return audioClips[rando];
        //return audioClips[Random.Range(0, 3)];

      return null;
    }

    // Start is called before the first frame update
    void Start()
    {
      //audioSrc.volume = 0.02f;
      // Play the main game sound
      audioSrc.clip = RandomClip();
      audioSrc.loop = true;
      audioSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
      if (confirm == 1)
      {
        playClaps();
      }

      if (confirm == 2)
      {
        playWrong();
        Debug.Log("wrong() call attempt");
      }

      confirm = 0;
    }

    // Play audio that designates the congrats message.
    public void playClaps()
    {
      //audioSrc.volume = 0.02f;

      if (clapsIndex < audioClips.Length)
        audioSrc.PlayOneShot(audioClips[4]);
      if (fireworksIndex < audioClips.Length)
        audioSrc.PlayOneShot(audioClips[5]);
      if (typeClip < audioClips.Length && typeClip >= 0)
        congratsSrc.PlayOneShot(audioClips[typeClip]);
    }

    public void playWrong()
    {
      int rando = Random.Range(12, 14);

      if (rando < audioClips.Length && rando >= 0)
        congratsSrc.PlayOneShot(audioClips[rando]);
    }
  }
