using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GUIDisplayTether : MonoBehaviour
{
    private const int incorrect = 2;
    private const int correct = 1;

    private float mass;
    private float tangentialVelocity;
    private float angularVelocity;
    private float ropeLength;
    private float centripetalForce;
    private float tension;
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

    // private float angVelRoundStep =
    // Start is called before the first frame update
    void Start()
    {
        // STILL HAVE TO FIGURE OUT THE RANGE FOR ANGULAR VELOCITY
        mass = Mathf.Round(UnityEngine.Random.Range(0.15f, 0.5f) / massRoundStep) * massRoundStep;
        ropeLength = Mathf.Round(UnityEngine.Random.Range(1f, 3f) / ropeRoundStep) * ropeRoundStep;
        angularVelocity = Mathf.Round(UnityEngine.Random.Range(1f, 5.5f) / velocityRoundStep) * velocityRoundStep;

        tangentialVelocity = ropeLength * angularVelocity;
        centripetalForce = (mass * tangentialVelocity * tangentialVelocity) / ropeLength;
        tension = centripetalForce;

        Debug.Log(" ");
        Debug.Log("Question 1");
        Debug.Log("mass: " + mass);
        Debug.Log("rope: " + ropeLength);
        Debug.Log("Angular velocity: " + angularVelocity);
        Debug.Log("Tangential velocity: " + tangentialVelocity);
        Debug.Log("Centripetal force: " + centripetalForce);
        Debug.Log(" ");

        stage = 1;
        correctConfetti = 0;

        scoreboard.SetText("Score: 0/2");
        all_data.SetText("Mass: " + mass.ToString("0.00") + " kg" + "\nRope length: " + ropeLength.ToString("0.00") + " m" +
         "\nAngular Velocity: " + angularVelocity.ToString("0.00") + " rad/s");


        /*
        // ######################### QUESTION 1.1.1 #######################

        // "A ball of mass " + mass + " kg is rotating horizontally around a pole with " +
        // "an angular velocity of " + angularVelocity + " rad/s.\n" +
        // "The length of the rope holding the ball has a length of " + ropeLength + "m.\n" +
        // "What is the tangential velocity of the ball? Please answer in m/s."

        // ANSWER: tangentialVelocity

        // ######################### QUESTION 1.1.2 #######################
        // CONTINUATION OF THE PREVIOUS QUESTION

        // "What is the centripetal force acting on the ball while it has " +
        // "a velocity of " + tangentialVelocity + " m/s? Please answer in Newtons."

        // ANSWER: centripetalForce
        */

        /*
        // ######################### QUESTION 1.2.1 #######################

        // "A ball has a mass of " + mass + " kg and is rotating horizontally around a pole " +
        // "with a tangential velocity of " + tangentialVelocity + " m/s.\n" +
        // "What is the centripetal force acting on the ball if the length of the rope is " + ropeLength + " m? " +
        // "Please answer in Newtons."

        // ANSWER: cetripetalForce
        */

        /*
        // ######################### QUESTION 1.3.1 #######################

        // "If a ball of mass " + mass + " kg is rotating horizontally around a pole at a " +
        // "velocity of " + tangentialVelocity + " m/s.\n" +
        // "What is the tension on the " + ropeLength + " m-long rope? Please answer in Newtons."

        // ANSWER: tension
        */

        /*
        // ######################### QUESTION 1.4.1 #######################
        // SAME AS THE PREVIOUS QUESTION BUT WITH ANGULAR VELOCITY

        // "If a ball of mass " + mass + " kg is rotating horizontally around a pole at an " +
        // "angular velocity of " + angularVelocity + " rad/s.\n" +
        // "What is the tension on the " + ropeLength + " m-long rope? Please answer in Newtons."

        // ANSWER: tension
        */

        /*
        // ######################### QUESTION 1.5.1 #######################
        // QUESTIONS FOR SOLVING FOR ALL THE UNKNOWNS

        // "A ball of mass " + mass + " kg is rotating horizontally around a pole with " +
        // "an angular velocity of " + angularVelocity + " rad/s.\n" +
        // "The length of the rope holding the ball has a length of " + ropeLength + "m.\n" +
        // "What is the tangential velocity of the ball? Please answer in m/s."

        // ANSWER: tangentialVelocity

        // ######################### QUESTION 1.5.2 #######################
        // "What is the tension on the rope? Please answer in Newtons"

        // ANSWER: tension

        // ######################### QUESTION 1.5.3 #######################
        // "What is the centripetal force acting on the ball? Please answer in Newtons"

        // ANSWER: centripetalForce
        */
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Return) && !mainDialogue.showInput)
      {
          flag = false;

          if (stage == 1)
          {
            answerText = user_ans.GetComponent<TMP_InputField>().text;
            actualAnswer = Convert.ToSingle(answerText);
            //stage++;

            if ((actualAnswer >= (tangentialVelocity * 0.98)) && (actualAnswer <= (tangentialVelocity * 1.02)))
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


            if((actualAnswer >= (centripetalForce * 0.98)) && (actualAnswer <= (centripetalForce * 1.02)))
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

      //Debug.Log("stage 2 " + stage);

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
        angularVelocity = Mathf.Round(UnityEngine.Random.Range(1f, 5.5f) / velocityRoundStep) * velocityRoundStep;

        tangentialVelocity = ropeLength * angularVelocity;
        centripetalForce = (mass * tangentialVelocity * tangentialVelocity) / ropeLength;
        tension = centripetalForce;

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
        mainDialogue.setSentence("A ball of mass " + mass.ToString("0.00") + " kg is rotating horizontally around a pole with " +
         "an angular velocity of " + angularVelocity.ToString("0.00") + " rad/s.\n" +
         "The length of the rope holding the ball has a length of " + ropeLength + "m.\n" +
         "What is the tangential velocity of the ball? \n\nPlease answer in m/s.");

         Debug.Log("Ans 1: " + tangentialVelocity);
         Debug.Log("Answer should be between " + tangentialVelocity * 0.98 + " and " + tangentialVelocity * 1.02);

      }

      else if (stage == 2)
      {
          mainDialogue.setSentence("What is the centripetal force acting on the ball while it has " + "a velocity of "
          + tangentialVelocity.ToString("0.00") + " m/s?\n\nPlease answer in Newtons.");

           Debug.Log("Answer should be between " + centripetalForce * 0.98 + " and " + centripetalForce * 1.02);
           Debug.Log("Ans 2: " + centripetalForce);
      }

      else if (stage == 3)
      {
        if (correctVal == 1)
        {
          TetherballSoundManager.confirm = 1;
          victory.Play();
          mainDialogue.setSentence("Congrats, you got all parts correct!\n\nPress enter to generate a similar question.");

          int rando = UnityEngine.Random.Range(1,8);

          if (rando == 1)
          {
            dialogue1.setSentence("YOU GOT THIS!");
            TetherballSoundManager.typeClip = 3;
          }

          else if (rando == 2)
          {
            dialogue1.setSentence("GREAT JOB!");
            TetherballSoundManager.typeClip = 5;
          }

          else if (rando == 3)
          {
            dialogue1.setSentence("AMAZING!");
            TetherballSoundManager.typeClip = 0;
          }

          else if (rando == 4)
          {
            dialogue1.setSentence("YES! THAT'S IT!");
            TetherballSoundManager.typeClip = 2;
          }

          else if (rando == 5)
          {
            dialogue1.setSentence("CONGRATS!");
            TetherballSoundManager.typeClip = 6;
          }

          else if (rando == 6)
          {
            dialogue1.setSentence("KEEP IT UP!");
            TetherballSoundManager.typeClip = 4;
          }

          else
          {
            dialogue1.setSentence("WONDERFUL!");
            TetherballSoundManager.typeClip = 1;
          }
        }

        else if (correctVal == 2)
        {
          mainDialogue.setSentence("Part two was incorrect.\nTry again!");
          TetherballSoundManager.confirm = incorrect;
        }

        else if (correctVal == 3)
        {
          mainDialogue.setSentence("Part one was incorrect.\nTry again!");
          TetherballSoundManager.confirm = incorrect;
        }

        else if (correctVal == 4)
        {
          mainDialogue.setSentence("Both parts were incorrect. Press enter to try again!");
          TetherballSoundManager.confirm = incorrect;
        }
      }

      yield return null;

    }

}
