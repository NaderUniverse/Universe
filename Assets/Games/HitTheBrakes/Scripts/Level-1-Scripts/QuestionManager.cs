using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using UnityEngine.VFX;
using TMPro;

public class QuestionManager : MonoBehaviour
{

    // text variables
    public TMP_Text questionText;
    public TMP_Text scoreText;
    public TMP_Text isCorrectText;
    public TMP_Text answer;
    public TMP_InputField input;
    string[] questions;

    // random variables storing calculation values
    private int force;
    private int time;
    private int mass;
    private int initialVelocity;
    private int finalVelocity;
    private double correctAnswer;

    // use for score at top right
    private int score = 0;
    private int total = 0;

    // firework object
    public GameObject fw;
    public GameObject typingAudio;

    // xConfetti animation for loss
    public GameObject xConfetti;
    public GameObject carPrefab;
    public GameObject answerMenu;


    // Start is called before the first frame update
    void Start()
    {
        questions = new string[2];
    }

    void Update()
    {
        // if enter button is pressed enter question
        if (Input.GetButtonDown("Submit"))
        {
            CheckAnswer();
        }
    }

    // show new question for user
    public void DisplayQuestion()
    {
        // stop showing answer menu
        answerMenu.SetActive(false);
        
        // spawn a new car
        Instantiate(carPrefab);

        // generate random values for calculation
        mass = Random.Range(1000, 2001);
        initialVelocity = Random.Range(50, 101);

        // convert from km/h to mph
        float metersPerSecond = (float)initialVelocity * 1000.0f / 3600.0f;

        // pick a random question from 2 possible question types
        int randomQuestion = Random.Range(0, 2);

        // force question
        if (randomQuestion == 0)
        {
            // time is between 2 and 4 seconds
            time = Random.Range(2, 5);
            // used for displaying the question to the user
            string q = "The driver of the car shown slams the brakes to bring it to a complete stop. " +
                       "Given that the time to stop is " + time.ToString() + " seconds, mass is " + mass.ToString() +
                       " kg, and inital Velocity is " + initialVelocity.ToString() +
                       " km/h. Find the force in Newtons required to come to a complete stop.";

            // calculate the correct answer for comparison
            correctAnswer = CalculateAnswer(mass, metersPerSecond, time);
            // this will set the answer displayed after they enter.
            answer.text = "The answer was " + Math.Round(correctAnswer, 2) + " N";

            Debug.Log(q + " " + correctAnswer);

            // set the 1st possible question to the resulting string
            questions[randomQuestion] = q;
        }

        // time question
        else
        {
            // force is between 9000 and 12000 newtons
            force = Random.Range(9000, 12001);

            // same as question 1 but asks for time instead of force
            string q = "The driver of the car shown slams the brakes to bring it to a complete stop. " +
                       "Given that the force required to stop is " + force.ToString() + " N, mass is " + mass.ToString() +
                       " kg, and inital Velocity is " + initialVelocity.ToString() +
                       " km/h. Find the time in seconds needed to come to a complete stop.";

            // pass in force this time
            correctAnswer = CalculateAnswer(mass, metersPerSecond, force);

            // for display purposes
            answer.text = "The answer was " + Math.Round(correctAnswer, 2) + "s";

            Debug.Log(q + " " + correctAnswer);

            questions[randomQuestion] = q;
        }

        // For Testing, REMOVE BEFORE FINAL PRODUCT!!!
        input.text = "" + Math.Round(correctAnswer, 2);

        // Type our randomly selected question out slowly for animation
        StartCoroutine(TypeQuestion(questions[randomQuestion]));
    }

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
    }

    public void StartAnimation()
    {
        if (isCorrectText.text == "Correct!")
        {
            // start firework
            fw.SetActive(true);

            // display green score color for correct
            StartCoroutine(FindObjectOfType<ScoreAnimation>().CorrectAnimation());
        }
        else if (isCorrectText.text == "Wrong!")
        {
            // start confetti
            xConfetti.SetActive(true);

            // display red score color for wrong
            StartCoroutine(FindObjectOfType<ScoreAnimation>().WrongAnimation());
        }
    }

    public void StopAnimations()
    {
        // stop confetti
        xConfetti.SetActive(false);

        // stop firework
        fw.SetActive(false);
        
        // stop coroutines so we can do score coroutine
        StopAllCoroutines();
        
        // stop typing audio
        // typingAudio.SetActive(false);

        // destroy the old car before spawning a new one.
        FindObjectOfType<DestroyCar>().Remove();
    }

    /*
    public void StartCorrectAnimations()
    {
        // start firework
        fw.SetActive(true);

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
    */


    // when user enters the answer call this
    public void CheckAnswer()
    {
        // reset our objects state so the animation can repeat itself
        StopAnimations();

        // make sure user answer is within 0.1 of correct answer
        if (Math.Abs(float.Parse(input.text) - correctAnswer) < 0.1f)
        {
            // increase score
            score++;

            // set answer menu text
            isCorrectText.text = "Correct!";

            // play animations for correct answer
            //StartCorrectAnimations();         
            StartAnimation();
        }
        else
        {
            // set answer menu text
            isCorrectText.text = "Wrong!";

            // play animations for wrong answer
            StartAnimation();
        }

        // increate total questions answered
        total++;

        // add score animation
        scoreText.text = "Score: " + score + "/" + total;

        // reset text in input box
        input.text = "";

        // change the question text to give instructions.
        questionText.text = "Press next to continue...";

        // Display menu that shows correct answer
        answerMenu.SetActive(true);
    }

    // calculate answer to problem
    float CalculateAnswer(int mass, float iVelocity, int time)
    {
        // formula for time / force
        return (float)mass * (iVelocity / 2.0f) / (float)time; 
    }
}
