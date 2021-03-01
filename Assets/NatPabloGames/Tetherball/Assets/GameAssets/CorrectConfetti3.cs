using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectConfetti3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        if(Question2Info.correctConfetti == 0)
        {
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
        else if(Question2Info.correctConfetti == 1)
        {
            gameObject.GetComponent<ParticleSystem>().Play();
        }
    }
}
