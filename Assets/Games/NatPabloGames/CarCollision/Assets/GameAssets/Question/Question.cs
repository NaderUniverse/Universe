using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
  public bool DBUG;
  // Masses
  public float mass_a;
  public float mass_b;

  // Initial velocities
  public float u_a;
  public float u_b;

  // Final Velocities
  public float v_a;
  public float v_b;

  // Coefficient of Restitution
  public float COR;

  // Rounding constants
  private float massRoundStep = 50f;
  private float velRoundStep = 0.5f;
  private float CORRoundStep = 0.05f;

  // Standard time unit;
  public float timeUnit;

  public TMP_InputField user_ans;
  private bool flag = false;
  private int displayFireworks = 0;
  public static int stage = 0;
  public string answerText = "0";
  public float actualAnswer = 0;
  public Dialogue mainDialogue;
  public Dialogue dialogue1;
  public AudioSource sound_correct;
  public AudioSource sound_incorrect;
  public AudioSource sound_game;
  public static int correctConfetti;
  public AudioSource victory;
  public Text scoreboard;
  private int num_correct = 0;
  private const int num_questions = 2;
  private const int incorrect = 2;
  private const int correct = 1;
  public TextMeshProUGUI all_data;
  //public TextMeshProUGUI all_data;

  public carMotion carA;
  public carMotion carB;

  // Start is called before the first frame update
  void Start()
  {
     // Setting standard time unit
     timeUnit = 0.1f;

    if (DBUG)
    {
      // // FOR DEBUGGING
      // mass_a = 2500;
      // mass_b = 1500f;

      // // FOR DEBUGGING
      // u_a = 20f;
      // u_b = -40f;

      // // FOR DEBUGGING
      // COR = 0.9f;
    }
    else
    {
      // Setting initial masses between 1500kg to 2500kg with steps of 250kg
      mass_a = Mathf.Round(UnityEngine.Random.Range(1500f, 2500f) / massRoundStep) * massRoundStep;
      mass_b = Mathf.Round(UnityEngine.Random.Range(1500f, 2500f) / massRoundStep) * massRoundStep;

      // Setting initial velocities between 20 m/s to 40 m/s with respective directions, with steps of 2.5 m/s
      u_a = Mathf.Round(UnityEngine.Random.Range(20f, 40f) / velRoundStep) * velRoundStep;
      u_b = Mathf.Round(UnityEngine.Random.Range(-40f, -20f) / velRoundStep) * velRoundStep;

      // Setting the Coefficient of Restitution: e=|Relative vel after collision|/|Relative vel before collision|
      COR = Mathf.Round(UnityEngine.Random.Range(0.1f, 0.9f) / CORRoundStep) * CORRoundStep;
    }


      /* Calculations
       *
       * Coefficient of restitution
       * COR = |v_b - v_a|/|u_a - u_b|
       * -> v_b = (COR * (u_a - u_b)) + v_a
       *
       * Initial momentum of system = Final momentum of system:
       * mass_a*u_a + mass_b*u_b = mass_a*v_a + mass_b*v_b
       * -> v_a = (mass_a*u_a + mass_b*u_b - mass_b*v_b) / (mass_a)
       * --> v_a = (mass_a*u_a + mass_b*u_b - mass_b*(COR*(u_a - u_b) + v_a)) / (mass_a)
       * ---> v_a*(1 + mass_b/mass_a) = (mass_a*u_a + mass_b*u_b - mass_b*(COR*(u_a - u_b))) / (mass_a)
       * ----> v_a = (mass_a*u_a + mass_b*u_b - mass_b*(COR*(u_a - u_b))) / (mass_a + mass_b)
       */

     // Calculating final velocity for Car A
     v_a = ((mass_a * u_a) + (mass_b * u_b) - (mass_b * (COR * (u_a - u_b)))) / (mass_a + mass_b);

     // Calculating final velocity for Car B
     v_b = (COR * (u_a - u_b)) + v_a;

     stage = 1;
     correctConfetti = 0;
     num_correct = 0;
     scoreboard.text = "Score: 0/2";

     //carA.setMovement();
     //carB.setMovement();

     all_data.SetText("Mass Car A: " + mass_a.ToString("0.00") + " kg" + "\nMass Car B: " + mass_b.ToString("0.00") + " kg" +
      "\nCar A Velocity: " + u_a.ToString("0.00") + " m/s" + "\nCar B Velocity: " + u_b.ToString("0.00") + " m/s" +
      "\nCoefficient of Restitution: " + COR.ToString("0.00"));
  }

  /*
   * ---------------------------QUESTION 1---------------------------
     "Cars A and B, with masses " + mass_a + "kg and " + mass_b + "kg respectively, are headed towards each other.\n" +
     "Car A is going to the right with a velocity of " + u_a + "m/s, while Car B is going towards the left with a velocity of " + u_b + "m/s.\n" +
     "If the coefficient of Restitution is " + COR + ". What would be the absolute velocity of Car A after the collision?\n" +
     "Please enter your answer in m/s."
   *
   * INFO GIVEN:
   *      mass_a
   *      mass_b
   *      u_a
   *      u_b
   *      COR
   *
   * ANSWER:
          v_a
   *
   * ---------------------------QUESTION 2---------------------------
     "If Car A has an absolute velocity of " + v_a + "m/s after the collision.\n" +
     "What is the absolute velocity of Car B after the collision?\n" +
     "Please enter the answer in m/s."
   *
   * INFO GIVEN:
          v_a
   *
   * ANSWER:
          v_b
   */


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

           if (v_a < 0)
           {
             if ((-actualAnswer >= (-v_a * 0.98)) && (-actualAnswer <= (-v_a * 1.02)) || actualAnswer == v_a)
             {
               num_correct++;
               //Debug.Log("Answer 1: correct");
               sound_correct.Play();
               scoreboard.text = "Score: " + num_correct + "/2";
             }

             else
             {
               sound_incorrect.Play();
             }
           }

           else
           {
             if ((actualAnswer >= (v_a * 0.98)) && (actualAnswer <= (v_a * 1.02)) || actualAnswer == v_a)
             {
               num_correct++;
               //Debug.Log("Answer 1: correct");
               sound_correct.Play();
               scoreboard.text = "Score: " + num_correct + "/2";
             }
             else
             {
               sound_incorrect.Play();
             }
           }
         }

         if (stage == 2)
         {
           answerText = user_ans.GetComponent<TMP_InputField>().text;
           actualAnswer = Convert.ToSingle(answerText);

           if (v_b < 0)
           {

             if((-actualAnswer >= (-v_b * 0.98)) && (-actualAnswer <= (-v_b * 1.02)) || actualAnswer == v_b)
             {
               num_correct++;
               //Debug.Log("Answer 2: correct");
               sound_correct.Play();
               scoreboard.text = "Score: " + num_correct + "/2";
             }

             else
             {
               sound_incorrect.Play();
             }
           }

           else
           {
             if((actualAnswer >= (v_b * 0.98)) && (actualAnswer <= (v_b * 1.02)) || actualAnswer == v_b)
             {
               num_correct++;
               //Debug.Log("Answer 2: correct");
               sound_correct.Play();
               scoreboard.text = "Score: " + num_correct + "/2";
             }

             else
             {
               sound_incorrect.Play();
             }
           }
         }

         Debug.Log(actualAnswer);

         stage++;
     }

     if (carA.collisionFlag == true)
     {
       Explosion.explosionOn = true;
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
       // play sound here
       if (!flag)
           StartCoroutine(changeText());
     }

     if (stage > 3)
     {
       Explosion.explosionOn = false;
       Explosion.activated = false;
       carA.restartMovement();
       carB.restartMovement();

       sound_game.Play();
       dialogue1.setSentence(" ");

       correctConfetti = 0;

       // Setting standard time unit
       timeUnit = 0.1f;

       // Setting initial masses between 1500kg to 2500kg with steps of 250kg
       mass_a = Mathf.Round(UnityEngine.Random.Range(1500f, 2500f) / massRoundStep) * massRoundStep;
       mass_b = Mathf.Round(UnityEngine.Random.Range(1500f, 2500f) / massRoundStep) * massRoundStep;

       // Setting initial velocities between 20 m/s to 40 m/s with respective directions, with steps of 2.5 m/s
       u_a = Mathf.Round(UnityEngine.Random.Range(20f, 40f) / velRoundStep) * velRoundStep;
       u_b = Mathf.Round(UnityEngine.Random.Range(-40f, -20f) / velRoundStep) * velRoundStep;

       // Setting the Coefficient of Restitution: e=|Relative vel after collision|/|Relative vel before collision|
       COR = Mathf.Round(UnityEngine.Random.Range(0.1f, 0.9f) / CORRoundStep) * CORRoundStep;

       // Calculating final velocity for Car A
       v_a = ((mass_a * u_a) + (mass_b * u_b) - (mass_b * (COR * (u_a - u_b)))) / (mass_a + mass_b);

       // Calculating final velocity for Car B
       v_b = (COR * (u_a - u_b)) + v_a;


       stage = 1;
       num_correct = 0;
       scoreboard.text = "Score: 0/2";

       all_data.SetText("Mass Car A: " + mass_a.ToString("0.00") + " kg" + "\nMass Car B: " + mass_b.ToString("0.00") + " kg" +
        "\nCar A Velocity: " + u_a.ToString("0.00") + " m/s" + "\nCar B Velocity: " + u_b.ToString("0.00") + " m/s" +
        "\nCoefficient of Restitution: " + COR.ToString("0.00"));
     }
   }

   IEnumerator changeText()
   {
     // Keep track whether we entered this state before.
     flag = true;

     if (stage == 1)
     {
       //u_b = -u_b;
       mainDialogue.setSentence("Cars A and B, with masses " + mass_a.ToString("0.00") + " kg and " + mass_b.ToString("0.00") + " kg respectively, are headed towards each other.\n" +
       "Car A is going to the right with a velocity of " + u_a.ToString("0.00") + " m/s, while Car B is going towards the left with a velocity of " + u_b.ToString("0.00") + " m/s.\n" +
       "If the coefficient of Restitution is " + COR.ToString("0.00") + ", what would be the absolute velocity of Car A after the collision?\n" +
       "Please enter your answer in m/s.");

        Debug.Log("Ans 1: " + v_a);
     }

     else if (stage == 2)
     {
         mainDialogue.setSentence("If Car A has an velocity of " + v_a.ToString("0.00") + " m/s after the collision.\n" +
         "What is the absolute velocity of Car B after the collision?\n" +
         "Please enter the answer in m/s.");

          Debug.Log("Ans 2: " + v_b);
     }

     else if (stage == 3)
     {

       if (num_correct == num_questions)
       {
         SoundManagerScript.confirm = 1;
         correctConfetti = UnityEngine.Random.Range(1,4);
         Debug.Log(correctConfetti + "res");
         sound_game.Stop();
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
           dialogue1.setSentence("LET'S GET IT!");
           SoundManagerScript.typeClip = 5;
         }

         else if (rando == 3)
         {
           dialogue1.setSentence("MARVELOUS!");
           SoundManagerScript.typeClip = 0;
         }

         else if (rando == 4)
         {
           dialogue1.setSentence("YES! THAT'S IT!");
           SoundManagerScript.typeClip = 2;
         }

         else if (rando == 5)
         {
           dialogue1.setSentence("EXCELLENT!");
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
         mainDialogue.setSentence("Your score is: " + num_correct + "/2\n\nPress Enter to try again!");
        // SoundManagerScript.confirm = incorrect;
       }
     }

     yield return null;

   }
}
