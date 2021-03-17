using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public AudioSource v1;
    public AudioSource v2;
    public AudioSource v3;
    
    //public Music song;

    public void playRandom()
    {

        int rand = Random.Range(0,2);
        if (rand == 0)
            v1.Play();
        else if (rand == 1)
            v2.Play();
        else
            v3.Play();

    }
}
