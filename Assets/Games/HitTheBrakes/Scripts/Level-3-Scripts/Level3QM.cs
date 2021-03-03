using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using UnityEngine.VFX;
using TMPro;


public class Level3QM : MonoBehaviour
{
    public GameObject car;
    // Start is called before the first frame update

    public RandomNumberGeneratorLevel3 randomNumber;    // text variables
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
    private double time = 0.0;
    private double acc = 0.0;
    //rand values
    private double distance  = 0.0;
    private double accelaration = 0.0;
    
    //feedback variables
    private int score = 0;
    private int total = 0;
    public GameObject wrongSound;
    public GameObject rightSound;
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
        if (Input.GetButtonDown("Submit"))
        {
            EnterAnswer();
        }//end if 
    }//end update

    // show new question for user
    public void DisplayQuestion()
    {
        Instantiate(car);
        answerMenu.SetActive(false);
        
        string question = "";

        //getRandom values
        randomNumber.Generate();
        distance = randomNumber.getDistance();
        accelaration = randomNumber.getAcceleration();

        //question
        question = "The driver tries to hit the brake, BUT WAIT! There is a brake malfunction! The car accelerates until it hits the wall. Given that the distance traveled is " + Math.Round(distance, 2) + 
        " meters and the acceleration of the car is " + Math.Round(accelaration, 2) + " m/s squared. Find the final velocity of the car before crashing.";
        //calculate the answer
        time = calcTime(distance, accelaration);
        finalVelocity = accelaration * time;
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
        rightSound.SetActive(false);
        wrongSound.SetActive(false);

        GameObject[] cars = GameObject.FindGameObjectsWithTag("car");

        foreach(var car in cars)
        {
            Destroy(car);
        }
    }//end of StopAnimations

    public void StartCorrectAnimations()
    {
        // start firework
        rightSound.SetActive(true);

        // start score animation
        StartCoroutine(FindObjectOfType<ScoreAnimation>().correctAnimation());
    }

    public void StartWrongAnimations()
    {
        // play animation for wrong answer
        wrongSound.SetActive(true);

        // display red score color for wrong
        StartCoroutine(FindObjectOfType<ScoreAnimation>().wrongAnimation());
    }

   
    double calcTime(double dist, double acc)
    {
        return Math.Sqrt((2*dist) / acc);
    }
    
}
