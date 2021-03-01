using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectConfetti2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        if(GUIdisplay2.correctConfetti == 0)
        {
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
        else if(GUIdisplay2.correctConfetti == 1)
        {
            gameObject.GetComponent<ParticleSystem>().Play();
        }
    }
}
