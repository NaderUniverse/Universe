using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GUIdisplay2 : MonoBehaviour
{
  private const int incorrect = 2;
  private const int correct = 1;

  private float mass;
  private float ropeLength;
  private float angularVelocity;
  private float tangentialVelocity;
  private float angleWithVertical;
  private float angleWithHorizontal;
  private float centripetalForce;
  private float tension;
  private float xForce;
  private float yForce;
  private float gravity = 9.81f;
  private float massRoundStep = 0.05f;
  private float ropeRoundStep = 0.1f;
  private float velocityRoundStep = 0.1f;

  public TMP_InputField user_ans;
  private bool flag = false;
  private int correctVal = 0;
  private int displayFireworks = 0;
  public int stage = 0;
  public string answerText = "0";
  public float actualAnswer = 0;
  public DialogueTether mainDialogue;
  public DialogueTether dialogue1;
  private bool quest1_correct = false;
  private bool quest2_correct = false;
  public AudioSource sound_correct;
  public AudioSource sound_incorrect;
  public static int correctConfetti;
  public AudioSource victory;
  public TextMeshProUGUI scoreboard;
  private int num_correct = 0;
  public TextMeshProUGUI all_data;


  // Start is called before the first frame update
  void Start()
  {
      // STILL HAVE TO FIGURE OUT THE RANGE FOR ANGULAR VELOCITY
      mass = Mathf.Round(UnityEngine.Random.Range(0.15f, 0.5f) / massRoundStep) * massRoundStep;
      ropeLength = Mathf.Round(UnityEngine.Random.Range(1f, 3f) / ropeRoundStep) * ropeRoundStep;
      angularVelocity = Mathf.Round(UnityEngine.Random.Range(1f, 5.5f) / velocityRoundStep) * velocityRoundStep;

      tangentialVelocity = ropeLength * angularVelocity;
      centripetalForce = (mass * tangentialVelocity * tangentialVelocity) / ropeLength;

      xForce = centripetalForce;
      yForce = mass * gravity;

      // Mathf.Tan IS IN RADIANS
      angleWithVertical = Mathf.Atan(xForce / yForce) * (180 / Mathf.PI);
      angleWithHorizontal = Mathf.Atan(yForce / xForce) * (180 / Mathf.PI);
      //angleWithVertical = 4;

      tension = Mathf.Sqrt((xForce * xForce) + (yForce * yForce));

      Debug.Log(" ");
      Debug.Log("Question 3");
      Debug.Log("mass: " + mass);
      Debug.Log("ropeLength: " + ropeLength);
      Debug.Log("Angular Velocity: " + angularVelocity);
      Debug.Log("x Force: " + xForce);
      Debug.Log("y Force: " + yForce);
      Debug.Log("Centripetal Force: " + centripetalForce);
      Debug.Log("Tangential Velocity: " + tangentialVelocity);
      Debug.Log("Angle With VERTICAL: " + angleWithVertical);
      Debug.Log("Angle With HORIZONTAL: " + angleWithHorizontal);
      Debug.Log("Tension: " + tension);
      Debug.Log(" ");

      stage = 1;
      correctConfetti = 0;
      num_correct = 0;
      scoreboard.SetText("Score: 0/2");
      all_data.SetText("Mass: " + mass.ToString("0.00") + " kg" + "\nRope length: " + ropeLength.ToString("0.00") + " m" +
       "\nAngular Velocity: " + angularVelocity.ToString("0.00") + " rad/s");

      /*
      // ######################### QUESTION 3.1.1 #######################

      // "A ball with a mass of " + mass " kg is connected to a " + ropeLength " m rope rotating around " +
      "a vertical pole at an angular velocity of " + angularVelocity + " rad/s.\n" +
      "What is the angle that the rope forms with the pole? Please enter your answer in degrees."

      ANSWER: angleWithVertical

      // ######################### QUESTION 3.1.2 #######################
      // CONTINUATION OF THE PREVIOUS QUESTION

      "What is the tension on the rope? Please enter your answer in Newtons."

      ANSWER: tension
      */

      /*
      // ######################### QUESTION 3.2.1 #######################
      // SAME AS 3.1 BUT WITH HORIZONTAL ANGLE

      "A ball of mass " + mass + "with a velocity of " + tangentialVelocity + " m/s is rotating around a pole " +
      "connected by a " ropeLength + " m long rope.\n" +
      "What is the angle that the rope makes with the horizontal? Please enter your answer in degrees."

      ANSWER: angleWithHorizontal

      // ######################### QUESTION 3.2.2 #######################
      // CONTINUATION OF THE PREVIOUS QUESTION, EXACTLY THE SAME AS 3.1.2

      "What is the tension on the rope? Please enter your answer in Newtons."

      ANSWER: tension
      */

      /*
      // ######################### QUESTION 3.3.1 #######################
      // ALL THE STEPS NEEDED TO SOLVE FOR ALL OF THE UNKNOWNS

      "A ball with a mass of " + mass " kg is connected to a " + ropeLength " m rope rotating around " +
      "a vertical pole at an angular velocity of " + angularVelocity + " rad/s.\n" +
      "What is the horizontal component of the tension? Please enter your answer in Newtons."

      ANSWER: xForce

      // ######################### QUESTION 3.3.2 #######################

      "What is the vertical component of the tension? Please enter your answer in Newtons."

      ANSWER: yForce

      // ######################### QUESTION 3.3.3 #######################

      "What is the tension on the rope? Please enter your answer in Newtons.

      ANSWER: tension

      // ######################### QUESTION 3.3.4 #######################

      "What is the tangential velocity of the ball? Please enter your answer in m/s"

      ANSWER: tangentialVelocity

      // ######################### QUESTION 3.3.5 #######################

      "What is the angle that the rope makes with the pole? Please enter your answer in degrees."

      ANSWER: angleWithVertical

      // ######################### QUESTION 3.3.6 #######################

      "What is the angle that the rope makes with the horizontal? Please enter your answer in degrees."

      ANSWER: angleWithHorizontal

      // ######################### QUESTION 3.3.7 #######################

      "What is the centripetal force acting on the ball? Please enter your answer in Newtons."

      ANSWER: centripetalForce
      */
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Return) && !mainDialogue.showInput)
    {
        flag = false;
        Debug.Log("stage again");

        if (stage == 1)
        {
          answerText = user_ans.GetComponent<TMP_InputField>().text;
          actualAnswer = Convert.ToSingle(answerText);
          //stage++;

          if ((actualAnswer >= (angleWithVertical * 0.98)) && (actualAnswer <= (angleWithVertical * 1.02)))
          {
            num_correct++;
            quest1_correct = true;
            //Debug.Log("Answer 1: correct");
            sound_correct.Play();
            scoreboard.SetText("Score: " + num_correct + "/2");
          }
          else
          {
            sound_incorrect.Play();
          }
        }

        if (stage == 2)
        {
          answerText = user_ans.GetComponent<TMP_InputField>().text;
          actualAnswer = Convert.ToSingle(answerText);
          //stage++;

          if((actualAnswer >= (tension * 0.98)) && (actualAnswer <= (tension * 1.02)))
          {
            num_correct++;
            quest2_correct = true;
            //Debug.Log("Answer 2: correct");
            sound_correct.Play();
            scoreboard.SetText("Score: " + num_correct + "/2");
          }

          else
          {
            sound_incorrect.Play();
          }
        }

        stage++;
    }

    if (stage == 1)
    {
      //Debug.Log("stage again");
      if (!flag)
        StartCoroutine(changeText());
    }

    if (stage == 2)
    {
      if (!flag)
          StartCoroutine(changeText());
    }

    if (stage == 3)
    {
      if(quest1_correct == true && quest2_correct == true)
      {
          correctVal = 1;
          correctConfetti = 1;
      }

      else if(quest1_correct == true && quest2_correct == false)
      {
          correctVal = 2;
      }

      else if(quest1_correct == false && quest2_correct == true)
      {
          correctVal = 3;
      }

      else
      {
        // both wrong
          correctVal = 4;
      }
      // play sound here
      if (!flag)
          StartCoroutine(changeText());
    }

    if (stage > 3)
    {
      dialogue1.setSentence(" ");

      correctVal = 0;
      correctConfetti = 0;
      quest1_correct = false;
      quest2_correct = false;

      mass = Mathf.Round(UnityEngine.Random.Range(0.15f, 0.5f) / massRoundStep) * massRoundStep;
      ropeLength = Mathf.Round(UnityEngine.Random.Range(1f, 3f) / ropeRoundStep) * ropeRoundStep;
      angularVelocity = UnityEngine.Random.Range(0.15f, 0.5f);

      tangentialVelocity = ropeLength * angularVelocity;
      centripetalForce = (mass * tangentialVelocity * tangentialVelocity) / ropeLength;

      xForce = centripetalForce;
      yForce = mass * gravity;

      // Mathf.Tan IS IN RADIANS
      angleWithVertical = Mathf.Atan(xForce / yForce) * (180 / Mathf.PI);
      angleWithHorizontal = Mathf.Atan(yForce / xForce) * (180 / Mathf.PI);

      tension = Mathf.Sqrt((xForce * xForce) + (yForce * yForce));


      stage = 1;
      num_correct = 0;
      scoreboard.SetText("Score: 0/2");

      all_data.SetText("Mass: " + mass.ToString("0.00") + " kg" + "\nRope length: " + ropeLength.ToString("0.00") + " m" +
       "\nAngular Velocity: " + angularVelocity.ToString("0.00") + " rad/s");
    }
  }

  IEnumerator changeText()
  {
    // Keep track whether we entered this state before.
    flag = true;

    if (stage == 1)
    {
      mainDialogue.setSentence("A ball with a mass of " +  mass.ToString("0.00") + " kg is connected to a " + ropeLength.ToString("0.00") + " m rope rotating around " +
      "a vertical pole at an angular velocity of " + angularVelocity.ToString("0.00") + " rad/s.\n" +
      "What is the angle that the rope forms with the pole? Please enter your answer in degrees.");

       Debug.Log("Ans 1: " + angleWithVertical);
    }

    else if (stage == 2)
    {
        mainDialogue.setSentence("What is the tension on the rope?\nMass of ball: " + mass.ToString("0.00") + "\nRope length: "
          + ropeLength.ToString("0.00") + "\nAngular Velocity: " + angularVelocity.ToString("0.00") + "\n\nPlease enter your answer in Newtons.");

         Debug.Log("Ans 2: " + tension);
    }

    else if (stage == 3)
    {
      if (correctVal == 1)
      {
        SoundManagerScript.confirm = 1;
        victory.Play();
        mainDialogue.setSentence("Congrats, you got all parts correct!\n\nPress enter to generate a similar question.");

        int rando = UnityEngine.Random.Range(1,8);

        if (rando == 1)
        {
          dialogue1.setSentence("YOU GOT THIS!");
          SoundManagerScript.typeClip = 3;
        }

        else if (rando == 2)
        {
          dialogue1.setSentence("GREAT JOB!");
          SoundManagerScript.typeClip = 5;
        }

        else if (rando == 3)
        {
          dialogue1.setSentence("AMAZING!");
          SoundManagerScript.typeClip = 0;
        }

        else if (rando == 4)
        {
          dialogue1.setSentence("YES! THAT'S IT!");
          SoundManagerScript.typeClip = 2;
        }

        else if (rando == 5)
        {
          dialogue1.setSentence("CONGRATS!");
          SoundManagerScript.typeClip = 6;
        }

        else if (rando == 6)
        {
          dialogue1.setSentence("KEEP IT UP!");
          SoundManagerScript.typeClip = 4;
        }

        else
        {
          dialogue1.setSentence("WONDERFUL!");
          SoundManagerScript.typeClip = 1;
        }
      }

      else if (correctVal == 2)
      {
        mainDialogue.setSentence("Part two was incorrect.\nTry again!");
        SoundManagerScript.confirm = incorrect;
      }

      else if (correctVal == 3)
      {
        mainDialogue.setSentence("Part one was incorrect.\nTry again!");
        SoundManagerScript.confirm = incorrect;
      }

      else if (correctVal == 4)
      {
        mainDialogue.setSentence("Both parts were incorrect. Press enter to try again!");
        SoundManagerScript.confirm = incorrect;
      }
    }

    yield return null;

  }

}
