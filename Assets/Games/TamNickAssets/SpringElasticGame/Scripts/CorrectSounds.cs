using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectSounds : MonoBehaviour
{
    public AudioSource CSound;
    public AudioSource CSound2;
    public AudioSource CSound3;
    public AudioSource CSound4;
    public AudioSource CSound5;
    public AudioSource CSound6;
    public AudioSource CSound7;
    
    
     public void playAudio()
    {
         int randSound;
         randSound = UnityEngine.Random.Range(0,6);
         randSound = randSound + 1;

         if (randSound == 1)
          {
            CSound2.Play();
          }

          else if (randSound == 2)
          {
              CSound3.Play();
          }

          else if (randSound == 3)
          {
              CSound4.Play();
          }

          else if (randSound == 4)
          {
              CSound5.Play();
          }

           else if (randSound == 5)
          {
              CSound6.Play();
          }

           else if (randSound == 6)
          {
              CSound7.Play();
          }
          

           else
          {
              CSound.Play();
          }
       // CSound.Play();
       // randSound = UnityEngine.Random.Range(1,5);
    }

    
}
