using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarParts : MonoBehaviour
{
    public AudioSource metalSounds;
    public bool alreadyPlayed = false;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" && !alreadyPlayed)
        {
            metalSounds.Play();
            alreadyPlayed = true;
        }
    }

}
