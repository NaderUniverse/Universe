using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectFire : MonoBehaviour
{
  public ParticleSystem fire;
    // Start is called before the first frame update
    void Start()
    {
      fire.Stop();
    }

    void Update()
    {

        if(Question.correctConfetti == 0)
        {
            //gameObject.GetComponent<ParticleSystem>().Stop();
            fire.Stop();
        }
        else if(Question.correctConfetti == 2)
        {
            //gameObject.GetComponent<ParticleSystem>().Play();
            fire.Play();
        }
    }
}
