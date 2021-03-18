using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncorrectSound : MonoBehaviour
{
    // Start is called before the first frame update
   public AudioSource ISound;
   public AudioSource ISound2;
   public AudioSource ISound3;
   public AudioSource ISound4;
   public AudioSource ISound5;
   public AudioSource ISound6;
   public AudioSource ISound7;
   public int randoSound;
   public int randoSound2;
   public int randoSound3;
   
   void Start()
    {
         randoSound = UnityEngine.Random.Range(1,7);
         randoSound2 = UnityEngine.Random.Range(1,7);
        
         if(randoSound == randoSound2 )
         {
             randoSound2 = randoSound2 + 1;
            
         }
         randoSound3 = UnityEngine.Random.Range(1,7);

           if(randoSound3 == randoSound || randoSound3 == randoSound2 )
         {
             randoSound3 = randoSound3 + 1;
            
            
         }



         else if(randoSound == randoSound2 || randoSound == randoSound3)
         {
             randoSound2 = UnityEngine.Random.Range(1,7);
             randoSound3 = UnityEngine.Random.Range(1,7);
         }

         else if(randoSound2 == randoSound || randoSound2 == randoSound3)
         {
             randoSound = UnityEngine.Random.Range(1,7);
             randoSound3 = UnityEngine.Random.Range(1,7);
         }

         /* else if(randoSound3 == randoSound2 || randoSound3 == randoSound)
          {
             randoSound = UnityEngine.Random.Range(1,7);
             randoSound2 = UnityEngine.Random.Range(1,7);
          }
         */

         else if(randoSound == randoSound2 && randoSound == randoSound3)
         {
            randoSound2 = UnityEngine.Random.Range(1,7);
            randoSound3 = UnityEngine.Random.Range(1,7);
         }

         else if(randoSound2 == randoSound && randoSound2 == randoSound3)
         {
            randoSound = UnityEngine.Random.Range(1,7);
            randoSound3 = UnityEngine.Random.Range(1,7);
         }

         else if(randoSound3 == randoSound && randoSound3 == randoSound2)
         {
            randoSound = UnityEngine.Random.Range(1,7);
            randoSound2 = UnityEngine.Random.Range(1,7);
         }

    
         
    }

     public void reRandom1()
    {
         randoSound = UnityEngine.Random.Range(1,7);
         randoSound2 = UnityEngine.Random.Range(1,7);
           if(randoSound == randoSound2 )
         {
             randoSound2 = randoSound2 + 1;
            
         }

         randoSound3 = UnityEngine.Random.Range(1,7);

         
           if(randoSound3 == randoSound )
         {
             randoSound3 = randoSound3 + 1;
            
         }

         else if(randoSound3 == randoSound2 )
         {
             randoSound3 = randoSound3 + 1;
            
         }


         if(randoSound == randoSound2 && randoSound == randoSound3)
         {
            randoSound2 = UnityEngine.Random.Range(1,7);
            randoSound3 = UnityEngine.Random.Range(1,7);
         }

         else if(randoSound2 == randoSound && randoSound2 == randoSound3)
         {
            randoSound = UnityEngine.Random.Range(1,7);
            randoSound3 = UnityEngine.Random.Range(1,7);
         }

         else if(randoSound3 == randoSound && randoSound3 == randoSound2)
         {
            randoSound = UnityEngine.Random.Range(1,7);
            randoSound2 = UnityEngine.Random.Range(1,7);
         }

         else if(randoSound == randoSound2 || randoSound == randoSound3)
         {
             randoSound2 = UnityEngine.Random.Range(1,7);
             randoSound3 = UnityEngine.Random.Range(1,7);
         }

         else if(randoSound2 == randoSound || randoSound2 == randoSound3)
         {
             randoSound = UnityEngine.Random.Range(1,7);
             randoSound3 = UnityEngine.Random.Range(1,7);
         }

          else if(randoSound3 == randoSound2 || randoSound3 == randoSound)
          {
             randoSound = UnityEngine.Random.Range(1,7);
             randoSound2 = UnityEngine.Random.Range(1,7);
          }

    }
 
    public void playAudio()
    {
        //randoSound = UnityEngine.Random.Range(1,5);
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

          //randoSound = UnityEngine.Random.Range(1,7);
       // CSound.Play();
    }
    public void playAudio2()
    {
        //randoSound = UnityEngine.Random.Range(1,5);
         if (randoSound2 == 1)
          {
            ISound2.Play();
          }


         else if (randoSound2 == 2)
          {
              ISound3.Play();
          }

          else if (randoSound2 == 3)
          {
              ISound4.Play();
          }

          else if (randoSound2 == 4)
          {
              ISound5.Play();
          }
           else if (randoSound2 == 5)
          {
              ISound6.Play();
          }
           else if (randoSound2 == 6)
          {
              ISound7.Play();
          }
        

           else
          {
              ISound.Play();
          }


          //randoSound2 = UnityEngine.Random.Range(1,7);
       // CSound.Play();
    }
    public void playAudio3()
    {
        //randoSound = UnityEngine.Random.Range(1,5);
         if (randoSound3 == 1)
          {
            ISound2.Play();
          }


         else if (randoSound3 == 2)
          {
              ISound3.Play();
          }

          else if (randoSound3 == 3)
          {
              ISound4.Play();
          }

          else if (randoSound3 == 4)
          {
              ISound5.Play();
          }
           else if (randoSound3 == 5)
          {
              ISound6.Play();
          }
           else if (randoSound3 == 6)
          {
              ISound7.Play();
          }
        

           else
          {
              ISound.Play();
          }


          //randoSound2 = UnityEngine.Random.Range(1,7);
       // CSound.Play();
    }
}
