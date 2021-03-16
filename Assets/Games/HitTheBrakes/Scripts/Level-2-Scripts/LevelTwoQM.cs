using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using UnityEngine.VFX;
using TMPro;

public class LevelTwoQM : MonoBehaviour
{

    // text variables
    public GameObject typingAudio;
    public TMP_Text questionText;
    public TMP_InputField input;
    public TMP_Text scoreText;
    public TMP_Text answer;
    public TMP_Text isCorrectText;

    // given values
    private double gravity = 9.81f;

    //calculated values
    private double finalVelocity = 0.0;
    private double acc = 0.0;

    //rand values
    private double mu = 0.0;
    private double dist = 0.0;
    private double theta = 0.0;
    
    //feedback variables
    private int score = 0;
    private int total = 0;
    public GameObject xConfetti;
    public GameObject checkMarks;
    public GameObject answerMenu;

    // Unused
    // private double initialVelocity = 0.0;
    // private double time = 0.0;

    void Start()
    {        
        DisplayQuestion();
    }//end start

    void Update()
    {
        // if enter button is pressed enter question
        if (Input.GetButtonDown("Submit"))
        {
            EnterAnswer();
        }//end if 
    }//end update

    // show new question for user
    public void DisplayQuestion()
    {
        answerMenu.SetActive(false);
        FindObjectOfType<SlopeAttributes>().SetSlope();
        GameObject slope = GameObject.Find("Slope");
        SlopeAttributes sa = slope.GetComponent<SlopeAttributes>();

        //getRandom values
        mu = Math.Round(sa.randomValues.getMU(), 2);
        dist = Math.Round(sa.randomValues.getDistance(), 2);
        theta = Math.Round(sa.randomValues.getTheta(), 2);

        //question
        string question = "The driver of the car above forgot to set the parking break before leaving the car! If the coefficient of friction is " +
                    mu.ToString() + ", the distance between the start and bottom of the slope is " + dist.ToString() +
                    " m, and the angle of the slope is " + theta.ToString() + " degrees. Find the Velocity (m/s) to the nearest hundreth of the car when it reaches the bottom of the slope. hint:(Remember to use gravity)";
        //calculate the answer
        acc = calcAcc(gravity, theta * (Math.PI / 180), mu);
        finalVelocity = calcFinalVelocity(acc, dist);
        answer.text = "The answer was " + Math.Round(finalVelocity, 2) + " m/s";
        //REMOVE
        input.text = "" + Math.Round(finalVelocity, 2);
        // Type our randomly selected question out slowly for animation
        StartCoroutine(TypeQuestion(question));
    }//end of DisplayQuestion

    public void EnterAnswer()
    {
        StopAnimations();

        if(Math.Abs(double.Parse(input.text) - finalVelocity) < 0.1f)
        {
            score++;
            StartCorrectAnimations();         
            isCorrectText.text = "Correct!";
        }
        else
        {
            StartWrongAnimations();
            isCorrectText.text = "Wrong!";
        }
        total++;
        
        //adjust score
        scoreText.text = "Score: " + score + "/" + total;

        // reset text in input box
        input.text = "";
        questionText.text = "Press next to continue...";
        //DisplayQuestion();
        answerMenu.SetActive(true);
    }//end of EnterAnswer

    // type out the question 1 letter at a time with delay
    IEnumerator TypeQuestion(string question)
    {
        //start typing audio
        typingAudio.SetActive(true);
        // start from nothing
        questionText.text = "";
        // for each letter in question
        foreach (char letter in question.ToCharArray())
        {
            // add letter one letter at a time
            questionText.text += letter;

            // wait 0.05 seconds between letters added
            yield return new WaitForSeconds(0.05f);
        }
        // stop typing audio
        typingAudio.SetActive(false);
    }//end of TypeQuestion

    public void StopAnimations()
    {
        // stop coroutines so we can do score coroutine
        StopAllCoroutines();

        // stop typing audio
        typingAudio.SetActive(false);

        //stops feedback animations
        checkMarks.SetActive(false);
        xConfetti.SetActive(false);
    }//end of StopAnimations

    public void StartCorrectAnimations()
    {
        // start firework
        checkMarks.SetActive(true);

        // start score animation
        StartCoroutine(FindObjectOfType<ScoreAnimation>().CorrectAnimation());
    }

    public void StartWrongAnimations()
    {
        // play animation for wrong answer
        xConfetti.SetActive(true);

        // display red score color for wrong
        StartCoroutine(FindObjectOfType<ScoreAnimation>().WrongAnimation());
    }

    //calculate accelaration
    double calcAcc(double grav, double theta, double mu)
    {
        return grav * (Math.Sin(theta) - (mu * Math.Cos(theta)));
    }

    // calaculate FinalVelocity
    double calcFinalVelocity(double acc, double dist)
    {
        if(acc < 0)
        {
            return acc * calcTime(dist, acc);
        }
        else
        {
            return Math.Sqrt(2 * acc * dist);
        }
    }
    double calcTime(double dist, double acc)
    {
        return Math.Sqrt((2*dist) / acc);
    }
}//end class
