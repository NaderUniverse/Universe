using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using UnityEngine.VFX;
using TMPro;

public class Level4QuestionManager : MonoBehaviour
{

    public GameObject car;
    public GameObject van;
    // Start is called before the first frame update

    public RandomNumberGeneratorLV4 randomNumber;    // text variables
    public GameObject typingAudio;
    public TMP_Text questionText;
    public TMP_InputField input;
    public TMP_Text scoreText;
    public TMP_Text answer;
    public TMP_Text isCorrectText;
    //physics variables
    //given values
    private double initialVelocity = 0.0;
    private double gravity = 9.81f;
    //calculated values
    private double finalVelocity = 0.0;
    private double carTime = 0.0;
    private double vanTime = 0.0;
    private double acc = 0.0;
    //rand values
    private double distance  = 0.0;
    private double accelaration = 0.0;

    private String questionAnswer;
    
    //feedback variables
    private int score = 0;
    private int total = 0;
    public GameObject xConfetti;
    public GameObject checkMarks;
    public GameObject answerMenu;
    // Start is called before the first frame update
    void Start()
    {    //UNCOMMENT FOR LOLS
        // for(int i = 0; i < 30; i++)
        // {    
        // Instantiate(car);
        // }
        DisplayQuestion();
    }
    //end start

    void Update()
    {
        // if enter button is pressed enter question
        if (Input.GetButtonDown("Submit") && !answerMenu.activeSelf)
        {
            EnterAnswer();
        }//end if 
    }//end update

    // show new question for user
    public void DisplayQuestion()
    {
        GameObject[] cars = GameObject.FindGameObjectsWithTag("car");

        foreach(var car in cars)
        {
            Destroy(car);
        }

        GameObject[] vans = GameObject.FindGameObjectsWithTag("Bus");

        foreach (var van in vans)
        {
            Destroy(van);
        }

        answerMenu.SetActive(false);
        
        string question = "";

        //getRandom values
        randomNumber.Generate();

        double carDistance = Math.Round(randomNumber.randomCarDistance, 2);
        double carAccel = Math.Round(randomNumber.randomCarAccel, 2);

        double vanDistance = Math.Round(randomNumber.randomVanDistance, 2);
        double vanAccel = Math.Round(randomNumber.randomVanAccel, 2);

        //question
        question = "The car and van are racing, but they don't notice the brick wall ahead of them! The car is going at an acceleration of " 
                    + carAccel + " meters per second squared and its distance from the wall is " 
                    + carDistance + " meters. The van is going at an acceleration of "
                    + vanAccel + " meters per second squared and its distance from the wall is "
                    + vanDistance + " meters. Which of the two vehicles will hit the brick wall first? (Type your answer as 'car' or 'van')";
        //calculate the answer
        carTime = calcTime(carDistance, carAccel);
        vanTime = calcTime(vanDistance, vanAccel);

        if (carTime < vanTime)
        {
            questionAnswer = "car";
        }
        else
        {
            questionAnswer = "van";
        }
        answer.text = "The answer was the " + questionAnswer;
        //REMOVE
        input.text = "" + questionAnswer;
        // Type our randomly selected question out slowly for animation
        StartCoroutine(TypeQuestion(question));
    }//end of DisplayQuestion

    public void EnterAnswer()
    {
        StopAnimations();
        Instantiate(car);
        Instantiate(van);
        if (input.text.ToLower().Equals(questionAnswer))
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

    // Stopping confetti, etc.
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
        StartCoroutine(FindObjectOfType<ScoreAnimation>().correctAnimation());
    }

    public void StartWrongAnimations()
    {
        // play animation for wrong answer
        xConfetti.SetActive(true);

        // display red score color for wrong
        StartCoroutine(FindObjectOfType<ScoreAnimation>().wrongAnimation());
    }

   
    double calcTime(double dist, double acc)
    {
        return Math.Sqrt((2*dist) / acc);
    }


}
