using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckConfetti : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(TreeStages.correctChecks == 0)
         {
             gameObject.GetComponent<ParticleSystem>().Stop();
         }
         else if(TreeStages.correctChecks == 1)
         {
             gameObject.GetComponent<ParticleSystem>().Play();
         }
    }
}
