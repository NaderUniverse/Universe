using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectMagic : MonoBehaviour
{
  public ParticleSystem magic;

  void Start()
  {
    magic.Stop();
  }

  void Update()
  {

      if(Question.correctConfetti == 0)
      {
          //gameObject.GetComponent<ParticleSystem>().Stop();
          magic.Stop();
      }
      else if(Question.correctConfetti == 3 || Question.correctConfetti == 4)
      {
          //gameObject.GetComponent<ParticleSystem>().Play();
          magic.Play();
      }
  }
}
