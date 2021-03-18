using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource VSound;
    public AudioSource VSound2;
    public AudioSource VSound3;
    public AudioSource VSound4;
    public AudioSource VSound5;
    public AudioSource VSound6;
    public AudioSource VSound7;
    public int VrandSound;
    //public int VrandSound2;


    void Start()
    {
         VrandSound = UnityEngine.Random.Range(1,7);


      
    }

    public void VreRandom()
    {
         VrandSound = UnityEngine.Random.Range(1,7);


    }


    public void playAudio()
    {
         //randSound = UnityEngine.Random.Range(1,5);
         if (VrandSound == 1)
          {
            VSound2.Play();
          }

          else if (VrandSound == 2)
          {
              VSound3.Play();
          }

          else if (VrandSound == 3)
          {
              VSound4.Play();
          }

          else if (VrandSound == 4)
          {
              VSound5.Play();
          }

           else if (VrandSound == 5)
          {
              VSound6.Play();
          }

           else if (VrandSound == 6)
          {
              VSound7.Play();
          }
          

           else
          {
              VSound.Play();
          }
       // CSound.Play();
       // randSound = UnityEngine.Random.Range(1,5);
    }

    public void StopAudio()
    {
        if (VrandSound == 1)
          {
            VSound2.Stop();
          }

          else if (VrandSound == 2)
          {
              VSound3.Stop();
          }

          else if (VrandSound == 3)
          {
              VSound4.Stop();
          }

          else if (VrandSound == 4)
          {
              VSound5.Stop();
          }

           else if (VrandSound == 5)
          {
              VSound6.Stop();
          }

           else if (VrandSound == 6)
          {
              VSound7.Stop();
          }
          

           else
          {
              VSound.Stop();
          } 
    }

    
}
