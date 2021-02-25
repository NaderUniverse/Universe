using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectSound : MonoBehaviour
{
    public AudioSource CSound;
    public AudioSource CSound2;
    public AudioSource CSound3;
    public AudioSource CSound4;
    public AudioSource CSound5;
    public AudioSource CSound6;
    public AudioSource CSound7;
    public int randSound;
    public int randSound2;
   


    void Start()
    {
         randSound = UnityEngine.Random.Range(1,7);
         randSound2 = UnityEngine.Random.Range(1,7);

         if(randSound == randSound2 )
         {
             randSound2 = randSound2 + 1;
            
         }
         

    }

    public void reRandom()
    {
         randSound = UnityEngine.Random.Range(1,7);
         randSound2 = UnityEngine.Random.Range(1,7);

         if(randSound == randSound2 )
         {
             randSound2 = randSound2 + 1;
            
         }
         
    }


    public void playAudio()
    {
         //randSound = UnityEngine.Random.Range(1,5);
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

     public void playAudio2()
    {
         //randSound = UnityEngine.Random.Range(1,5);
         if (randSound2 == 1)
          {
            CSound2.Play();
          }

          else if (randSound2 == 2)
          {
              CSound3.Play();
          }

          else if (randSound2 == 3)
          {
              CSound4.Play();
          }

          else if (randSound2 == 4)
          {
              CSound5.Play();
          }

           else if (randSound2 == 5)
          {
              CSound6.Play();
          }

           else if (randSound2 == 6)
          {
              CSound7.Play();
          }

          
          

           else
          {
              CSound.Play();
          }
          // randSound2 = UnityEngine.Random.Range(1,5);
       // CSound.Play();
    }
}
