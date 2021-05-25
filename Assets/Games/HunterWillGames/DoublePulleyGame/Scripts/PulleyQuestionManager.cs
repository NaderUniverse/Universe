using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
using System;

//Question 1 Calculate final velocity of A and B after t = 1.0 - 3.0
public class PulleyQuestionManager : MonoBehaviour
{
    //TmpPro
    public Button StartButton;
    public TMP_Text BText;
    public GameObject L1;
    public GameObject L2;
    public GameObject L3;
    //Animation Clips
    public Animator CageMoveLeft;
    public Animator CageMoveRight;
    //
    //Declarations
    //Int
    public int a, b;//A needs to be between 2-4 and B needs to be inbetween 5-7
    public int Score = 0;
    public int questionPart = 0;
    public int QuestionCounter = 1;
    public int tChange = 0;
    public int wrong = 0;
    //float
    //distance is between 0.25m - 2.0m for part 2)xA,xB is distance traveled 
    public float t, distance, acceleration, xB, xA;//t is inbetween 1.0 - 3.0, for part 3) needs to be inbetween 2.0 - 3.0 could use two variables for this
    public float tmp, VB, VA, DTA;//DTA stands for distance traveled for A
    //Text/strings
    public TMP_Text input, output;
    public string question;
    private string answer;
    string Ans;
    public TMP_InputField uInput;
    public bool Test;
    // Start is called before the first frame update
    void Start()
    {
        DisplayQuestion();
        StartButton.onClick.AddListener(TaskOnClick);
        t = (float)Math.Round(Random.Range(1.0f, 3.0f), 2);
        a = Random.Range(2, 4);
        b = Random.Range(5, 7);
        xB = Random.Range((float)0.25, 2);
        CageMoveRight.enabled = false;
        CageMoveLeft.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        qMath();
        Test = uInput.GetComponent<TMP_InputField>().isFocused;
        // if enter button is pressed enter question
        if (Input.GetButtonDown("Submit"))
        {

            EnterAnswer();      
            
        }
        if (questionPart == 3 && tChange == 0)
        {
            //if we are on the third question part we change the time between 2 to 3 seconds
            t = (float)Math.Round(Random.Range(2.0f, 3.0f), 2);
            tChange++;
        }
    }
    void TaskOnClick()
    {
        string question1 = "";
        string question2 = "";
        string question3 = "";
        BText.text = "Click to see question again..";

        question1 = "The Kings pulley system is released from rest, given that the king on the right weighs " + b +
                    "kg, and the king on the left weighs " + a + "kg, Find the final velocity of both kings " + t
                  + " seconds after releasing the system from rest. ";

        question2 = "For the next part, Calculate the Acceleration of the king on the right in m/s^3";

        question3 = "Finally Calculate the distance traveled by the king on the left after " + t +"seconds."  ;


        if(QuestionCounter == 1)
        {
              StartCoroutine(TypeQuestion(question1));
              StartCageAnimations();
        }
        if (QuestionCounter == 2)
        {
            StartCoroutine(TypeQuestion(question2));
        }
        if (QuestionCounter == 3)
        {
            StartCoroutine(TypeQuestion(question3));
        }

    }
    void qMath()
    {


        //first question
        tmp = (2 * xB) / t;
        VB = tmp;
        VA = -VB / 2;

        Ans = VB + "," + VA;

        //Second question
        tmp = (2 * xB) / (t * t);
        acceleration = tmp;

        //Third question

        DTA = (float)(0.5 * acceleration * (t * t));
    }
    void DisplayQuestion()
    {
        string question = "";
       

        question = "The king has been kidnapped and is being held hostage by an evil wizard, to save him. "
            + "you will have to answer 3 questions on double pulleys are you up for the task? Remember the wise man is here to help you." + 
            " Press the start button to begin. ";

        StartCoroutine(TypeQuestion(question));

    }
    void EnterAnswer()
    {
        switch (questionPart)
        {
            case 1:
                       

                if (uInput.text.Equals(Ans))
                {
                    output.text = "Congrats, you have solved my first question can you solve the second one though let us find out. \n Press the button to continue...";
                    questionPart++;
                    QuestionCounter++;
                    L1.SetActive(true);
                    BText.text = "Next Part";
                }
                else
                {
                    uInput.ActivateInputField();
                    output.text = "Try again maybe they should have sent someone else to save the king.";
                  

                }
    



                break;
            case 2:
                if (uInput.text.Equals(acceleration.ToString()))
                {
                    output.text = "Wow, you really know your stuff on to the last and hardest of my questions.";
                    questionPart++;
                    QuestionCounter++;
                    L2.SetActive(true);
                    BText.text = "Final Part";
                }
                else
                {
                    output.text = "You will never beat me";
                }
              

                break;
            case 3:
                if (uInput.text.Equals(DTA.ToString()))
                {
                    output.text = "You have defeated me the king is yours; I greatly underestimated your knowledge in double pulleys.";
                    QuestionCounter++;
                    questionPart++;
                    L3.SetActive(true);
                }
                else
                {
                    output.text = "Wow you were so close but still wrong try again";
                }
             
                break;


        }

    }

    //Starts the cage animations
    void StartCageAnimations()
    {
        //Right cage animator
        CageMoveRight.enabled = true;
        CageMoveRight.Play("King Animation");
        //Left Cage animator for the first part of the question
        CageMoveLeft.enabled = true;
        CageMoveLeft.Play("Left King Movement");


    }
    void StopAnimations()
    {

        //stops all coroutines
        StopAllCoroutines();


    }
    void StartCorrectAnimations()
    {

    }
    void StartWrongAnimations()
    {

    }
    IEnumerator TypeQuestion(string question)
    {

        // create the empty text
        output.text = "";
        // for each letter in question
        foreach (char letter in question.ToCharArray())
        {
            //display one letter at a time
            output.text += letter;

            // wait 0.05 seconds between letters added
            yield return new WaitForSeconds(0.05f);
        }

    }//end of TypeQuestion
}