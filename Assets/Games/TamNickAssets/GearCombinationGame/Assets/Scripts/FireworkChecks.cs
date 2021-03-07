using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEditor.VFX;
//using UnityEditor.Experimental.Rendering.HDPipeline;
using UnityEditor.VFX.UI;

public class FireworkCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GUIDisplay.fireworkChecks == 0)
         {
            gameObject.GetComponent<VisualEffect>().Stop();
         }
        else if(GUIDisplay.fireworkChecks == 1)
        {
             gameObject.GetComponent<VisualEffect>().Play();
         }  
    }
}
