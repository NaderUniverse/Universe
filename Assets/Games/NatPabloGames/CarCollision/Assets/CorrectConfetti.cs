using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Drag your particle system in, adjust your Object (EX. Question/GuiDisplay2/Treestages)
public class CorrectConfetti : MonoBehaviour
{
  public ParticleSystem confetti;
    // Start is called before the first frame update
    void Start()
    {
      confetti.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        if(Question.correctConfetti == 0 || Question.correctConfetti == 2)
        {
            //gameObject.GetComponent<ParticleSystem>().Stop();
            confetti.Stop();
        }
        else if(Question.correctConfetti == 1)
        {
            //gameObject.GetComponent<ParticleSystem>().Play();
            confetti.Play();
        }
    }
}
