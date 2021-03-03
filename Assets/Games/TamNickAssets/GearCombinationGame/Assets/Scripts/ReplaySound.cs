using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySound : MonoBehaviour
{
   public AudioSource RPSound;
   public AudioSource RPSound2;
   public AudioSource RPSound3;
   public AudioSource RPSound4;
   public AudioSource RPSound5;
   public AudioSource sound1;

   public int RPrandoSound;
   
   
   void Start()
    {
         RPrandoSound = UnityEngine.Random.Range(0,2);
         
        
        
    }

     public void RPreRandom1()
    {
         RPrandoSound = UnityEngine.Random.Range(0,2);
        

    }
 
    public void RPplayAudio()
    {
        //RPreRandom1();
        Debug.Log(RPrandoSound);
         if (RPrandoSound == 1)
          {
            Debug.Log("Playing 2nd audio");
            RPSound2.Play();
          }

           else if (RPrandoSound == 2)
          {
            Debug.Log("Playing 3rd audio");
            RPSound3.Play();
          }

           else if (RPrandoSound == 3)
          {
            Debug.Log("Playing 4th audio");
            //RPSound3.Play();
          }

           else if (RPrandoSound == 4)
          {
            Debug.Log("Playing 5th audio");
            //RPSound3.Play();
          }


      

           else
          {
             Debug.Log("Playing default audio");
              RPSound.Play();
          }

        
      
    }
    
}
