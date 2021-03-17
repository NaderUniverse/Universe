using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncorrectSounds : MonoBehaviour
{
    public AudioSource ISound;
   public AudioSource ISound2;
   public AudioSource ISound3;
   public AudioSource ISound4;
   public AudioSource ISound5;
   public AudioSource ISound6;
   public AudioSource ISound7;
   
    public void playAudio()
    {
        int randoSound = UnityEngine.Random.Range(0,6);
        randoSound = randoSound + 1;
         if (randoSound == 1)
          {
            ISound2.Play();
          }

         else if (randoSound == 2)
          {
              ISound3.Play();
          }

          else if (randoSound == 3)
          {
              ISound4.Play();
          }

          else if (randoSound == 4)
          {
              ISound5.Play();
          }
           else if (randoSound == 5)
          {
              ISound6.Play();
          }
           else if (randoSound == 6)
          {
              ISound7.Play();
          }
        

           else
          {
              ISound.Play();
          }

          
    }

}
