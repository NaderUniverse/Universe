using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerTether : MonoBehaviour
{
    public static int confirm = 0;
    public AudioClip[] audioClips;
    public AudioSource audioSrc;


    AudioClip RandomClip()
    {
      return audioClips[Random.Range(0, 2)];
    }

    // Start is called before the first frame update
    void Start()
    {
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

      confirm = 0;
    }

    // Play audio that designates the congrats message.
    public void playClaps()
    {
      audioSrc.PlayOneShot(audioClips[4]);
      audioSrc.PlayOneShot(audioClips[5]);
    }

}
