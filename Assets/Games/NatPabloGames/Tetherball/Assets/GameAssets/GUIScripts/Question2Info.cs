using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Question2Info : MonoBehaviour
{
    public float mass;
    public float ropeLength;
    public float gravity = 9.81f;
    public float theta;

    public float height;
    public float pEPos1;
    public float kEPos1;
    public float velocity;
    public float angularVelocity;
    public float pEPos2;
    public float kEPos2;
    public float totalEnergy;

    private float massRoundStep = 2f;
    private float ropeRoundStep = 0.25f;
    private float thetaRoundStep = 5f;

    public TMP_InputField user_ans;
    private bool flag = false;
    //private int correctVal = 0;
    private int displayFireworks = 0;
    public int stage = 0;
    public string answerText = "0";
    public float actualAnswer = 0;
    public DialogueTether mainDialogue;
    public DialogueTether dialogue1;
    public AudioSource sound_correct;
    public AudioSource sound_incorrect;
    public static int correctConfetti;
    public AudioSource victory;
    public TextMeshProUGUI scoreboard;
    private int num_correct = 0;
    private const int num_questions = 3;
    private const int incorrect = 2;
    private const int correct = 1;
    public TextMeshProUGUI all_data;


    // Start is called before the first frame update
    void Start()
    {
        // All the basic variables given by the question
        mass = Mathf.Round(UnityEngine.Random.Range(18f, 42f) / massRoundStep) * massRoundStep;
        ropeLength = Mathf.Round(UnityEngine.Random.Range(1f, 3f) / ropeRoundStep) * ropeRoundStep;
        theta = Mathf.Round(UnityEngine.Random.Range(25f, 60f) / thetaRoundStep) * thetaRoundStep;

        Debug.Log(Mathf.Cos(theta * Mathf.PI / 180));

        // Initial height at release
        height = ropeLength - ropeLength * Mathf.Cos(theta * Mathf.PI / 180);

        // Total Energy from the initial position: only Potential Energy
        totalEnergy = mass * gravity * height;

        // Energy at Position 1, release: All potential energy, no kinetic energy
        pEPos1 = totalEnergy;
        kEPos1 = 0;

        // Velocity at the lowest point of the pendulum
        angularVelocity = Mathf.Sqrt(2 * gravity * height) / ropeLength;
        velocity = angularVelocity * ropeLength;

        // Energy at Position 2, the lowest point of the pendulum: All kinetic energy, no potential energy
        pEPos2 = 0;
        kEPos2 = totalEnergy;

        stage = 1;
        correctConfetti = 0;
        num_correct = 0;
        scoreboard.SetText("Score: 0/3");

        all_data.SetText("Mass: " + mass.ToString("0.00") + " kg" + "\nRope length: " + ropeLength.ToString("0.00") + " m" +
         "\nTheta: " + theta.ToString("0.00") + " degrees");



        /*
        // ######################### QUESTION 2.1 #######################

        "A kid is playing in a " + ropeLength + " meter-long swing with a combined mass of " + mass + " kg, if the biggest angle that the " +
        "kid has with the vertical is known to be " + theta + " degrees.\n" +
        "What is the total potential energy of the kid at that angle? Please enter your answer in Joules."

        // Info needed:
                        mass
                        ropeLength
                        theta

        ANSWER: pEPos1

        // ######################### QUESTION 2.2 #######################

        "Knowing that the highest Potential Energy is " + pEPos1 + " J, what would be the maximum speed at which the kid go?\n" +
        "Please enter your answer in m/s^2."

        // Info needed:
                        ropeLength
                        theta

        ANSWER: velocity

        // ######################### QUESTION 2.3 #######################

        "What would be the maximum Kinetic Energy of the kid?

        // Info needed:
                        mass
                        ropeLength
                        theta

        ANSWER: kEPos2

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

            if ((actualAnswer >= (pEPos1 * 0.98)) && (actualAnswer <= (pEPos1 * 1.02)))
            {
              num_correct++;
              //Debug.Log("Answer 1: correct");
              sound_correct.Play();
              scoreboard.SetText("Score: " + num_correct + "/3");
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

            if((actualAnswer >= (velocity * 0.98)) && (actualAnswer <= (velocity * 1.02)))
            {
              num_correct++;
              //Debug.Log("Answer 2: correct");
              sound_correct.Play();
              scoreboard.SetText("Score: " + num_correct + "/3");
            }

            else
            {
              sound_incorrect.Play();
            }
          }

          if (stage == 3)
          {
            answerText = user_ans.GetComponent<TMP_InputField>().text;
            actualAnswer = Convert.ToSingle(answerText);
            //stage++;

            if((actualAnswer >= (kEPos2 * 0.98)) && (actualAnswer <= (kEPos2 * 1.02)))
            {
              num_correct++;
              //Debug.Log("Answer 2: correct");
              sound_correct.Play();
              scoreboard.SetText("Score: " + num_correct + "/3");
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
        if (!flag)
            StartCoroutine(changeText());
      }

      if (stage == 4)
      {
        if(num_correct == num_questions)
        {
            correctConfetti = 1;
        }

        // play sound here
        if (!flag)
            StartCoroutine(changeText());
      }

      if (stage > 4)
      {
        dialogue1.setSentence(" ");
        correctConfetti = 0;

        // All the basic variables given by the question
        mass = Mathf.Round(UnityEngine.Random.Range(18f, 42f) / massRoundStep) * massRoundStep;
        ropeLength = Mathf.Round(UnityEngine.Random.Range(1f, 3f) / ropeRoundStep) * ropeRoundStep;
        theta = Mathf.Round(UnityEngine.Random.Range(25f, 60f) / thetaRoundStep) * thetaRoundStep;

        // Initial height at release
        height = ropeLength - ropeLength * Mathf.Sin(theta);

        // Total Energy from the initial position: only Potential Energy
        totalEnergy = mass * gravity * height;

        // Energy at Position 1, release: All potential energy, no kinetic energy
        pEPos1 = totalEnergy;
        kEPos1 = 0;

        // Velocity at the lowest point of the pendulum
        angularVelocity = Mathf.Sqrt(2 * gravity * height) / ropeLength;
        velocity = angularVelocity * ropeLength;

        // Energy at Position 2, the lowest point of the pendulum: All kinetic energy, no potential energy
        pEPos2 = 0;
        kEPos2 = totalEnergy;


        stage = 1;
        num_correct = 0;
        scoreboard.SetText("Score: 0/3");

        all_data.SetText("Mass: " + mass.ToString("0.00") + " kg" + "\nRope length: " + ropeLength.ToString("0.00") + " m" +
         "\nTheta: " + theta.ToString("0.00") + " degrees");
      }
    }

    IEnumerator changeText()
    {
      // Keep track whether we entered this state before.
      flag = true;

      if (stage == 1)
      {
        mainDialogue.setSentence("A kid is playing in a " + ropeLength.ToString("0.00") + " meter-long swing with a combined mass of " + mass.ToString("0.00") + " kg. If the biggest angle that the " +
          "kid has with the vertical is known to be " + theta.ToString("0.00") + " degrees, " +
          "what is the total potential energy of the kid at that angle? Please enter your answer in Joules.");

         Debug.Log("Ans 1: " + pEPos1);
      }

      else if (stage == 2)
      {
          mainDialogue.setSentence("Knowing that the highest Potential Energy is " + pEPos1.ToString("0.00") + " J, what would be the maximum speed at which the kid goes?\n\n" + "Rope Length: " + ropeLength.ToString("0.00") +
            "m\nAngle: " + theta.ToString("0.00") + " degrees." + "\n\nPlease enter your answer in m/s<sup>2</sup>.");

           Debug.Log("Ans 2: " + velocity);
      }

      else if (stage == 3)
      {
          mainDialogue.setSentence("What would be the maximum Kinetic Energy of the kid?" + "\n\nRope Length: " + ropeLength.ToString("0.00") +
            "m\nAngle: " + theta.ToString("0.00") + " degrees" + "\nMass: " + mass.ToString("0.00") + " kg");

           Debug.Log("Ans 3: " + kEPos2);
      }

      else if (stage == 4)
      {
        if (num_correct == num_questions)
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

        else
        {
          mainDialogue.setSentence("Your score is: " + num_correct + "/3\n\nTry again!");
          SoundManagerScript.confirm = incorrect;
        }
      }

      yield return null;
  }
}
