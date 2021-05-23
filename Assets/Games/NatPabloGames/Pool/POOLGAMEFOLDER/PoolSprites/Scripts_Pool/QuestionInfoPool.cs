using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
public class QuestionInfoPool : MonoBehaviour
{
    // Given values
    public float vA;        // m/s
    public float vB;        // m/s
    public float theta;     // degrees
    public float eR;        // No unit

    // Step values
    public float vAStep = 0.25f;
    public float vBStep = 0.25f;
    public float thetaStep = 2.5f;
    public float eRStep = 0.01f;

    // Calculation Values
    public float pi = Mathf.PI;
    public float vAN;       // m/s
    public float vBN;       // m/s
    public float vAT;       // m/s
    public float vBT;       // m/s

    // Wanted values
    public float vAPN;   // m/s
    public float vBPN;   // m/s
    public float vAPT;   // m/s
    public float vBPT;   // m/s
    public float lossKE;     // J

    public TMP_InputField user_ans;
    private bool flag = false;
    public static int stage = 0;
    public string answerText = "0";
    public float inputAnswer = 0;
    public Dialogue_NP questionDialogue;
    public Dialogue_NP victoryDialogue;
    public AudioSource sound_correct;
    public AudioSource sound_incorrect;
    public AudioSource sound_game;
    public AudioSource victory;
    public TextMeshProUGUI scoreboard;
    private int num_correct = 0;
    private const int num_questions = 5;
    private const int incorrect = 2;
    private const int correct = 1;
    public TextMeshProUGUI all_data;

    public BallMovement cue;

    // Start is called before the first frame update
    void Start()
    {
        variables();

        stage = 1;
        num_correct = 0;
        scoreboard.text = "Score: 0/5";
        questData();
    }

    /*
    // Questions information
    // -----------------------------------------------------------------------------------------------

    // Initial Given values (Hint values)
    vA
    vB
    theta
    eR

    // Question 1
    "Pool balls A and B hit each other as shown, with A going at a velocity of " + vA + " m/s travelling in " +
    "the direction indicated by the angle Θ = " + theta + " degrees as shown. With B going at " + vB + " m/s, while "+
    "travelling perpendicularly to A, such that the angle alpha = 90 - " + theta + ".\n" +
    "Calculate the velocity for A in the T-direction after collision.\n" +
    "Please enter your answer in m/s and round to three decimals places."

    // Answer: vAPT
    // -----------------------------------------------------------------------------------------------

    // Question 2
    "Knowing that the velocity of A in the T-direction after collision is " + vAPT + " m/s.\n" +
    "What is the velocity of B in the T-direction after collision?\n" +
    "Please enter your answer in m/s and round to three decimal places."

    // Answer: vBPT
    // -----------------------------------------------------------------------------------------------

    // Question 3
    "What is the velocity of B in the N-direction after collision?\n"
    "Please enter your answer in m/s and round to three decimal places."

    // Answer: vBPN
    // -----------------------------------------------------------------------------------------------

    // Question 4
    "Knowing that the velocity of B in the N-direction after collision is " + vBPN + " m/s, calculate " +
    "the velocity of A in the N-direction after collision.\n"
    "Please enter your answer in m/s and round to three decimal places."

    // Answer: vAPN
    // -----------------------------------------------------------------------------------------------

    // Question 5
    "Knowing that the velocities in the N-direction of both A and B are " + vAPN + " and " + vBPN + " m/s " +
    "respectively, as well as their velocities in the T-direction are " + vAPT + " and " + vBPT + " m/s " +
    "respectively. Calculate the total loss in kinetic energy following the impact, with a coefficient " +
    "of restitution of " + eR +".\n" +
    "Please enter your answer in N and round to three decimal places."

    // Answer: lossKE
    */

    private void CheckAnswer(float calculatedAnswer)
    {
      answerText = user_ans.GetComponent<TMP_InputField>().text;
      inputAnswer = Convert.ToSingle(answerText);

      if (inputAnswer < 0)
      {
        if ((inputAnswer <= (calculatedAnswer * 0.98)) && (inputAnswer >= (calculatedAnswer * 1.02)))
        {
          num_correct++;
          sound_correct.Play();
          scoreboard.text = "Score: " + num_correct + "/5";
          StartCoroutine(ChangeColorCorrect());
        }
        else
        {
          sound_incorrect.Play();
          StartCoroutine(ChangeColorIncorrect());
        }
      }
      else
      {
        if ((inputAnswer >= (calculatedAnswer * 0.98)) && (inputAnswer <= (calculatedAnswer * 1.02)))
        {
          num_correct++;
          sound_correct.Play();
          scoreboard.text = "Score: " + num_correct + "/5";
          StartCoroutine(ChangeColorCorrect());
        }
        else
        {
          sound_incorrect.Play();
          StartCoroutine(ChangeColorIncorrect());
        }
      }
    }

    private IEnumerator ChangeColorCorrect()
    {
      scoreboard.color = Color.green;
      yield return new WaitForSeconds(0.2f);
      scoreboard.color = Color.white;
      yield return new WaitForSeconds(0.2f);
      scoreboard.color = Color.green;
      yield return new WaitForSeconds(0.2f);
      scoreboard.color = Color.white;
    }

    private IEnumerator ChangeColorIncorrect()
    {
      scoreboard.color = Color.red;
      yield return new WaitForSeconds(0.2f);
      scoreboard.color = Color.white;
      yield return new WaitForSeconds(0.2f);
      scoreboard.color = Color.red;
      yield return new WaitForSeconds(0.2f);
      scoreboard.color = Color.white;
    }

    // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Return) && !questionDialogue.lockBool)
    {
      flag = false;

      if (stage == 1)
      {
        CheckAnswer(vAPT);
      }

      if (stage == 2)
      {
        CheckAnswer(vBPT);
      }

      if (stage == 3)
      {
        CheckAnswer(vBPN);
      }

      if (stage == 4)
      {
        CheckAnswer(vAPN);
      }

      if (stage == 5)
      {
      CheckAnswer(lossKE);
      }

      stage++;
    }

    if (stage == 1)
    {
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

    if (stage == 5)
    {
      if (!flag)
          StartCoroutine(changeText());
    }

    if (stage == 6)
    {
      if (!flag)
          StartCoroutine(changeText());
    }

    if (stage > 6)
    {
      sound_game.Play();
      victoryDialogue.setSentence(" ");

      stage = 1;
      num_correct = 0;
      scoreboard.text = "Score: 0/5";
      variables();
      questData();
      cue.restartMovement();
    }
}

private void questData()
{
  all_data.text = "Velocity A: " + vA.ToString("0.00") + " m/s\nVelocity B: " + vB.ToString("0.00") + " m/s\nTheta: " + theta.ToString("0.00") + " degrees";
}

private void variables()
{
  vA = Mathf.Round(UnityEngine.Random.Range(1f, 3f) / 0.25f) * 0.25f;
  vB = Mathf.Round(UnityEngine.Random.Range(1f, 3f) / 0.25f) * 0.25f;
  theta = Mathf.Round(UnityEngine.Random.Range(30f, 45f) / 2.5f) * 2.5f;
  eR = Mathf.Round(UnityEngine.Random.Range(0.75f, 0.9f) / 0.05f) * 0.05f;

  vAN = - vA * Mathf.Cos(theta * pi/180);
  vBN = vB * Mathf.Cos(pi/2 - theta * pi/180);
  vAT = vA * Mathf.Sin(theta * pi/180);
  vBT = vB * Mathf.Sin(pi/2 - theta * pi/180);

  vBPN = (eR * (vAN - vBN) + vAN + vBN) / 2;
  vAPN = vAN + vBN - vBPN;
  vAPT = vAT;
  vBPT = vBT;
  lossKE = ((vA*vA + vB*vB) - (vAPN*vAPN + vAPT*vAPT + vBPN*vBPN + vBPT*vBPT)) / 2;
}

IEnumerator changeText()
  {
    // Keep track whether we entered this state before.
    flag = true;

    if (stage == 1)
    {
      //u_b = -u_b;
      questionDialogue.setSentence("Pool balls A and B hit each other as shown, with A going at a velocity of " + vA.ToString("0.00") + " m/s travelling in " +
      "the direction indicated by the angle Θ = " + theta.ToString("0.00") + " degrees as shown. With B going at " + vB.ToString("0.00") + " m/s, while "+
      "travelling perpendicularly to A, such that the angle alpha = " + theta.ToString("0.00") + ".\n" +
      "Calculate the velocity for A in the T-direction after collision.\n" +
      "Please enter your answer in m/s and round to three decimals places.");

       Debug.Log("Ans 1: " + vAPT);
    }

    else if (stage == 2)
    {
        questionDialogue.setSentence("Knowing that the velocity of A in the T-direction after collision is " + vAPT.ToString("0.00") + " m/s.\n" +
          "What is the velocity of B in the T-direction after collision?\n" +
          "Please enter your answer in m/s and round to three decimal places.");

         Debug.Log("Ans 2: " + vBPT);
    }

    else if (stage == 3)
    {
      questionDialogue.setSentence("What is the velocity of B in the N-direction after collision?\n" +
      "Please enter your answer in m/s and round to three decimal places.");

       Debug.Log("Ans 3: " + vBPN);
    }

    else if (stage == 4)
    {
      questionDialogue.setSentence("Knowing that the velocity of B in the N-direction after collision is " + vBPN.ToString("0.00") + " m/s, calculate " +
        "the velocity of A in the N-direction after collision.\n" +
        "Please enter your answer in m/s and round to three decimal places.");

       Debug.Log("Ans 4: " + vAPN);
    }

    else if (stage == 5)
    {
      questionDialogue.setSentence("Knowing that the velocities in the N-direction of both A and B are " + vAPN.ToString("0.00") + " m/s and " + vBPN.ToString("0.00") + " m/s " +
      "respectively, as well as their velocities in the T-direction are " + vAPT.ToString("0.00") + " m/s and " + vBPT.ToString("0.00") + " m/s " +
      "respectively. Calculate the total loss in kinetic energy following the impact, with a coefficient " +
      "of restitution of " + eR.ToString("0.00") +".\n" +
      "Please enter your answer in N and round to three decimal places.");

       Debug.Log("Ans 5: " + lossKE);
    }

    else if (stage == 6)
    {

      if (num_correct == num_questions)
      {
        SoundManager_NP.confirm = 1;
        sound_game.Stop();
        victory.Play();
        questionDialogue.setSentence("Congrats, you got all parts correct!\n\nPress enter to generate a similar question.");

        int rando = UnityEngine.Random.Range(1,8);

        if (rando == 1)
        {
          victoryDialogue.setSentence("GREAT JOB!");
          SoundManager_NP.typeClip = SoundManager_NP.GreatJob;
        }

        else if (rando == 2)
        {
          victoryDialogue.setSentence("GOOD JOB!");
          SoundManager_NP.typeClip = SoundManager_NP.GoodJob;
        }

        else if (rando == 3)
        {
          victoryDialogue.setSentence("MARVELOUS!");
          SoundManager_NP.typeClip = SoundManager_NP.Marvelous;
        }

        else if (rando == 4)
        {
          victoryDialogue.setSentence("YES! THAT'S IT!");
          SoundManager_NP.typeClip = SoundManager_NP.Yes;
        }

        else if (rando == 5)
        {
          victoryDialogue.setSentence("CONGRATS YOU WIN!");
          SoundManager_NP.typeClip = SoundManager_NP.Congrats;
        }

        else if (rando == 6)
        {
          victoryDialogue.setSentence("GREAT WORK!");
          SoundManager_NP.typeClip = SoundManager_NP.GreatWork;
        }

        else
        {
          victoryDialogue.setSentence("CONGRATULATIONS!");
          SoundManager_NP.typeClip = SoundManager_NP.Congratulations;
        }
      }

      else
      {
        questionDialogue.setSentence("Your score is: " + num_correct + "/5\n\nPress Enter to try again!");
      }

      cue.setVelocities();
    }

    yield return null;

  }












}
