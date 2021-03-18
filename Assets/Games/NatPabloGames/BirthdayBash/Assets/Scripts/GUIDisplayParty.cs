using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class GUIDisplayParty : MonoBehaviour
{
    // Known values
    public bool DBUG;
    private float gravity = 9.81f;
    public float mass;
    public float length;
    public float velocity;

    // Asked values
    public float height;
    public float distance;
    public float tension;

    // Rounding resolution
    private float massStep = 0.25f;
    private float lengthStep = 0.1f;
    private float velocityStep = 0.25f;

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
    public TextMeshProUGUI scoreboard;
    private int num_correct = 0;
    private const int num_questions = 3;
    private const int incorrect = 2;
    private const int correct = 1;
    public TextMeshProUGUI all_data;
    public HealthBar healthBar;
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject arrows;

    // Start is called before the first frame update
    void Start()
    {
        if (DBUG)
        {
            // Input own values on the Inspector tab
        }
        else
        {
            // Generating random variables and rounding them
            mass = Mathf.Round(UnityEngine.Random.Range(0.5f, 2f) / massStep) * massStep;
            length = Mathf.Round(UnityEngine.Random.Range(1f, 1.5f) / lengthStep) * lengthStep;
            velocity = Mathf.Round(UnityEngine.Random.Range(0.5f, 2f) / velocityStep) * velocityStep;
        }

        // Calculations
        // height = 1/(2g) * v^2
        height = 1/(2 * gravity) * velocity*velocity;

        // distance = sqrt(2*L*h - h^2)
        distance = Mathf.Sqrt(2 * length * height - height*height);

        // tension
        tension = (mass * velocity*velocity) / length;

        // Changing units where necessary
        height = height * 100;  // m to cm
        distance = distance * 100;  // m to cm
        tension = tension; // N stay same

        /* Questions
        // ------------------QUESTION 1------------------
        "A piñata of mass " + mass + " kg is hanging at a distance of " + length + " m below the ceiling." +
        "During  a birthday party, a child hit it such that its horizontal velocity becomes " + velocity +
        " m/s.\n" +
        "Find the height it travels before it comes to rest. " +
        "Please enter answer in cm and round to three decimal places."

        // GIVEN: mass, length, velocity
        // ANSWER: height

        // ------------------QUESTION 2------------------
        "If the height the piñata reached was " + height + " m. Find the horizontal distance it travels." +
        "Please enter answer in cm and round to three decimal places."

        // GIVEN: mass, length, velocity
        //        height?
        // ANSWER: distance

        // ------------------QUESTION 2------------------
        "If the height reached was  " + height + " m, and the distance travelled was " + distance + " m." +
        "Find the tension exerted by the rope for the given condition." +
        "Please enter answer in N and round to three decimal places."

        // GIVEN: mass, legnth, velocity
        //        height, distance?
        // ANSWER: tension
        */

        stage = 1;
        correctConfetti = 0;
        num_correct = 0;
        scoreboard.text = "Score: 0/3";

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        all_data.text = "Mass: " + mass.ToString("0.000") + " kg" + "\nLength: " + length.ToString("0.000")
        + " m" + "\nVelocity: " + velocity.ToString("0.000") + " m/s";

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Return) && !mainDialogue.lockBool)
  {
      flag = false;

      if (stage == 1)
      {
        answerText = user_ans.GetComponent<TMP_InputField>().text;
        actualAnswer = Convert.ToSingle(answerText);

          if ((actualAnswer >= (height * 0.98)) && (actualAnswer <= (height * 1.02)))
          {
            num_correct++;
            //Debug.Log("Answer 1: correct");
            sound_correct.Play();
            scoreboard.text = "Score: " + num_correct + "/3";
            currentHealth -= 33;
            healthBar.SetHealth(currentHealth);
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

          if((actualAnswer >= (distance * 0.98)) && (actualAnswer <= (distance * 1.02)))
          {
            num_correct++;
            //Debug.Log("Answer 2: correct");
            sound_correct.Play();
            scoreboard.text = "Score: " + num_correct + "/3";
            currentHealth -= 33;
            healthBar.SetHealth(currentHealth);
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

          if((actualAnswer >= (tension * 0.98)) && (actualAnswer <= (tension * 1.02)))
          {
            num_correct++;
            //Debug.Log("Answer 2: correct");
            sound_correct.Play();
            scoreboard.text = "Score: " + num_correct + "/3";
            currentHealth -= 33;
            healthBar.SetHealth(currentHealth);
          }

          else
          {
            sound_incorrect.Play();
          }
      }

      Debug.Log(actualAnswer);

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
    if (!flag)
        StartCoroutine(changeText());
  }

  if (stage > 4)
  {
    sound_game.Play();
    dialogue1.setSentence(" ");

    correctConfetti = 0;

    stage = 1;
    num_correct = 0;
    scoreboard.text = "Score: 0/3";
    healthBar.SetHealth(maxHealth);
    arrows.SetActive(false);

    variables();
  }
}

private void variables()
{
  // Generating random variables and rounding them
  mass = Mathf.Round(UnityEngine.Random.Range(0.5f, 2f) / massStep) * massStep;
  length = Mathf.Round(UnityEngine.Random.Range(1f, 1.5f) / lengthStep) * lengthStep;
  velocity = Mathf.Round(UnityEngine.Random.Range(0.5f, 2f) / velocityStep) * velocityStep;
  // Calculations
  // height = 1/(2g) * v^2
  height = 1/(2 * gravity) * velocity*velocity;

  // distance = sqrt(2*L*h - h^2)
  distance = Mathf.Sqrt(2 * length * height - height*height);

  // tension
  tension = (mass * velocity*velocity) / length;

  height = height * 100;  // m to cm
  distance = distance * 100;  // m to cm
  tension = tension; // N stay same


  all_data.text = "Mass: " + mass.ToString("0.000") + " kg" + "\nLength: " + length.ToString("0.000")
  + " m" + "\nVelocity: " + velocity.ToString("0.000") + " m/s";
}

IEnumerator changeText()
  {
    // Keep track whether we entered this state before.
    flag = true;

    if (stage == 1)
    {
      //u_b = -u_b;
      mainDialogue.setSentence("A piñata of mass " + mass.ToString("0.000") + " kg is hanging at a distance of " + length.ToString("0.000") + " m below the ceiling." +
      " During a birthday party, the birthday girl hits it such that its horizontal velocity becomes " + velocity.ToString("0.000") +
      " m/s. " +
      "Find the height it travels before it comes to rest. " +
      "Please enter your answer in cm and round to three decimal places.");

       Debug.Log("Ans 1: " + height);
    }

    else if (stage == 2)
    {
        mainDialogue.setSentence("If the height the piñata reached was " + height.ToString("0.000") + " m. Find the horizontal distance it travels." +
          " Please enter answer in cm and round to three decimal places."
);

         Debug.Log("Ans 2: " + distance);
    }

    else if (stage == 3)
    {
      mainDialogue.setSentence("If the height reached was  " + height.ToString("0.000") + " m, and the distance travelled was " + distance.ToString("0.000") + " m." +
        " Find the tension exerted by the rope for the given condition." +
        " Please enter answer in N and round to three decimal places.");

       Debug.Log("Ans 3: " + tension);
    }

    else if (stage == 4)
    {

      if (num_correct == num_questions)
      {
        SoundManagerScript.confirm = 1;
        correctConfetti = UnityEngine.Random.Range(1,4);
        Debug.Log(correctConfetti + "res");
        sound_game.Stop();
        victory.Play();
        mainDialogue.setSentence("Congrats, you got all parts correct!\n\nPress enter to generate a similar question.");
        arrows.SetActive(true);

        int rando = UnityEngine.Random.Range(1,8);

        if (rando == 1)
        {
          dialogue1.setSentence("GREAT JOB!");
          SoundManagerScript.typeClip = 3;
        }

        else if (rando == 2)
        {
          dialogue1.setSentence("GOOD JOB!");
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
          dialogue1.setSentence("CONGRATS YOU WIN!");
          SoundManagerScript.typeClip = 6;
        }

        else if (rando == 6)
        {
          dialogue1.setSentence("GREAT WORK!");
          SoundManagerScript.typeClip = 4;
        }

        else
        {
          dialogue1.setSentence("CONGRATULATIONS!");
          SoundManagerScript.typeClip = 1;
        }
      }

      else
      {
        mainDialogue.setSentence("Your score is: " + num_correct + "/3\n\nPress Enter to try again!");
      }
    }

    yield return null;

  }
}
