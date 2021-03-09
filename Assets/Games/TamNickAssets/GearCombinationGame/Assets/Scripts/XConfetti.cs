using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XConfetti : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
         if(GUIDisplay.incorrectChecks == 0)
         {
             gameObject.GetComponent<ParticleSystem>().Stop();
         }
         else if(GUIDisplay.incorrectChecks == 1)
         {
             gameObject.GetComponent<ParticleSystem>().Play();
         }
    }
}
